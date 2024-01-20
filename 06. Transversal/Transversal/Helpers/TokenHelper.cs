using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Transversal
{
    public class TokenHelper
    {
        public const string Issuer = "http://gestionpruebas.com.co";
        public const string Audience = "http://gestionpruebas.com.co";
        
        public const string Secret = "cThIIoDvwdueQB468K5xDc5633seEFoqwxjF_xSJyQQ";

        public static async Task<string> GenerateAccessToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.UTF8.GetBytes(Secret);

            var claimsIdentity = new ClaimsIdentity(new[] {
         new Claim(ClaimTypes.NameIdentifier, userId.ToString())
     });

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Issuer = Issuer,
                Audience = Audience,
                Subject = claimsIdentity,
                Expires = DateTime.Now.AddMonths(6),
                SigningCredentials = signingCredentials,

            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return await System.Threading.Tasks.Task.Run(() => tokenHandler.WriteToken(securityToken));
        }
        public static async Task<string> GenerateRefreshToken()
        {
            var secureRandomBytes = new byte[32];

            using var randomNumberGenerator = RandomNumberGenerator.Create();
            await System.Threading.Tasks.Task.Run(() => randomNumberGenerator.GetBytes(secureRandomBytes));

            var refreshToken = Convert.ToBase64String(secureRandomBytes);

            return refreshToken;
        }
    }
}
