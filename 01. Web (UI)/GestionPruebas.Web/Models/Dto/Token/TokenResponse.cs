#nullable disable
using System.Text.Json.Serialization;

namespace GestionPruebas.Web.Models
{
    public class TokenResponse : BaseResponse
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
        [JsonPropertyName("userId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int UserId { get; set; }
        [JsonPropertyName("nombreUsuario")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string NombreUsuario { get; set; }
    }
}
