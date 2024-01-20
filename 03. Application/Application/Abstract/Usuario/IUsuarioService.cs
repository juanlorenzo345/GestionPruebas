using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Dto;

namespace Application.Abstract
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> GetInfoAsync(int userId);
        Task<TokenResponse> LoginAsync(LoginRequest loginRequest);
        Task<SignupResponse> SignupAsync(SignupRequest signupRequest);
    }
}
