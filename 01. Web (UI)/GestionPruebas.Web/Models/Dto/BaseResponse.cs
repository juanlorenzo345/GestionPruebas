#nullable disable
using System.Net;
using System.Text.Json.Serialization;

namespace GestionPruebas.Web.Models
{
    public class BaseResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("statusCode")]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Error { get; set; }
    }
}
