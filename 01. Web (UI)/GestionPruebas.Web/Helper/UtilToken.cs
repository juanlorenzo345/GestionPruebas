using System.IdentityModel.Tokens.Jwt;

namespace GestionPruebas.Web.Helper
{
    public class UtilToken
    {
        public string ExtractNameIdFromToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            if (jsonToken != null)
            {
                var nameIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "nameid");

                if (nameIdClaim != null)
                {
                    return nameIdClaim.Value;
                }
            }

            return null;
        }
    }
}
