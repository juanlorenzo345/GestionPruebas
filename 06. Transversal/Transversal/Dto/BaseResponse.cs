#nullable disable
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Transversal
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ErrorCode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Error { get; set; }
    }
}
