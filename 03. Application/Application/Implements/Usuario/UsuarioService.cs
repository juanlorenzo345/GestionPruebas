#nullable disable
using Application.Abstract;
using Domain.Model;
using Infraestructure.Interface;
using Transversal;
using Transversal.Dto;

namespace Application.Implements
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository; 
        }

        public async Task<UsuarioResponse> GetInfoAsync(int userId)
        {
            var user = await usuarioRepository.GetInfoAsync(userId);

            if (user == null)
            {
                return new UsuarioResponse
                {
                    Success = false,
                    Error = "No user found",
                    ErrorCode = "I001"
                };
            }

            return new UsuarioResponse
            {
                Success = true,
                Email = user.Email,
                NombreUsuario = user.NombreUsuario,
                FechaActualizacion = user.FechaActualizacion
            };
        }

        public async Task<TokenResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await usuarioRepository.LoginAsync(loginRequest);

            if (!user.Success)
            {
                return new TokenResponse
                {
                    Success = user.Success,
                    Error = user.Error,
                    ErrorCode = user.ErrorCode
                };
            }
            else
            {
                return new TokenResponse
                {
                    Success = user.Success,
                    AccessToken = user.AccessToken,
                    RefreshToken = user.RefreshToken,
                    UserId = user.UserId,
                    NombreUsuario = user.NombreUsuario,
                };
            }
        }

        public async Task<SignupResponse> SignupAsync(SignupRequest signupRequest)
        {
            var existingUser = await usuarioRepository.SignupAsync(signupRequest);

            if (existingUser == null)
            {
                return new SignupResponse
                {
                    Success = existingUser.Success,
                    Error = existingUser.Error,
                    ErrorCode = existingUser.ErrorCode
                };
            }
            else
            {
                return new SignupResponse { Success = existingUser.Success, Email = existingUser.Email};
            }
        }
    }
}
