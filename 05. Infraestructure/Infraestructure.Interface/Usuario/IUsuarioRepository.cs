using Domain.Model;
using Transversal.Dto;

namespace Infraestructure.Interface
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetInfoAsync(int userId);
        Task<TokenResponse> LoginAsync(LoginRequest loginRequest);
        Task<SignupResponse> SignupAsync(SignupRequest signupRequest);
    }
}
