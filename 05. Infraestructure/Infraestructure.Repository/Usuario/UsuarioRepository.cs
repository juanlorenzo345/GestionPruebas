#nullable disable
using Domain.Model;
using Infraestructure.Interface;
using Transversal.Dto;
using Transversal;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DBGestionPruebasContext tasksDbContext;
        private readonly ITokenRepository tokenRepository;

        public UsuarioRepository(DBGestionPruebasContext tasksDbContext, ITokenRepository tokenRepository)
        {
            this.tasksDbContext = tasksDbContext;
            this.tokenRepository = tokenRepository;
        }

        public async Task<Usuario> GetInfoAsync (int userId)
        {
            return await tasksDbContext.Usuarios.FindAsync(userId);
        }

        public async Task<TokenResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = tasksDbContext.Usuarios.SingleOrDefault(user => user.Estado && user.Email == loginRequest.Email);

            if (user == null)
            {
                return new TokenResponse
                {
                    Success = false,
                    Error = "Email not found",
                    ErrorCode = "L02"
                };
            }
            
            var passwordHash = PasswordHelper.GetSHA1Hash(loginRequest.Password);

            if (user.PasswordHash != passwordHash)
            {
                return new TokenResponse
                {
                    Success = false,
                    Error = "Invalid Password",
                    ErrorCode = "L03"
                };
            }

            var token = await Task.Run(() => tokenRepository.GenerateTokensAsync(user.Id));

            return new TokenResponse
            {
                Success = true,
                AccessToken = token.Item1,
                RefreshToken = token.Item2,
                UserId = user.Id,
                NombreUsuario = user.NombreUsuario,
            };
        }

        public async Task<SignupResponse> SignupAsync(SignupRequest signupRequest)
        {
            var existingUser = await tasksDbContext.Usuarios.FirstOrDefaultAsync(user => user.Email == signupRequest.Email);

            if (existingUser != null)
            {
                return new SignupResponse
                {
                    Success = false,
                    Error = "User already exists with the same email",
                    ErrorCode = "S02"
                };
            }

            if (signupRequest.Password != signupRequest.ConfirmPassword)
            {
                return new SignupResponse
                {
                    Success = false,
                    Error = "Password and confirm password do not match",
                    ErrorCode = "S03"
                };
            }

            if (signupRequest.Password.Length <= 7) 
            {
                return new SignupResponse
                {
                    Success = false,
                    Error = "Password is weak",
                    ErrorCode = "S04"
                };
            }

            var salt = PasswordHelper.GetSecureSalt();
            var passwordHash = PasswordHelper.GetSHA1Hash(signupRequest.Password);
            var user = new Usuario
            {
                Email = signupRequest.Email,
                PasswordHash = passwordHash,
                NombreUsuario = signupRequest.NombreUsuario,
                IdUsuarioActualizacion = signupRequest.IdUsuarioActualizacion,
                FechaActualizacion = signupRequest.FechaActualizacion,
                Estado = signupRequest.Estado,
            };

            await tasksDbContext.Usuarios.AddAsync(user);

            var saveResponse = await tasksDbContext.SaveChangesAsync();

            if (saveResponse >= 0)
            {
                return new SignupResponse { Success = true, Email = user.Email };
            }

            return new SignupResponse
            {
                Success = false,
                Error = "Unable to save the user",
                ErrorCode = "S05"
            };

        }
    }
}
