#nullable disable
using System.Text.Json.Serialization;

namespace GestionPruebas.Web.Models.Dto
{   
        public class AspirantePruebaSeleccionResponseDto
        {
            public List<AspirantePruebaSeleccionDto> aspirantePruebaSeleccions { get; set; }
        }

        public class AspirantePruebaSeleccionDto
        {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("idAspirante")]
        public int IdAspirante { get; set; }
        [JsonPropertyName("aspirante")]
        public string Aspirante { get; set; }
        [JsonPropertyName("idPruebaSeleccion")]
        public int IdPruebaSeleccion { get; set; }
        [JsonPropertyName("pruebaSeleccion")]
        public string PruebaSeleccion { get; set; }
        [JsonPropertyName("calificacion")]
        public decimal? Calificacion { get; set; }
        [JsonPropertyName("idEstadoPrueba")]
        public int IdEstadoPrueba { get; set; }
        [JsonPropertyName("estadoPrueba")]
        public string EstadoPrueba { get; set; }
        [JsonPropertyName("estado")]
        public bool Estado { get; set; }
        [JsonPropertyName("idUsuarioActualizacion")]
        public int IdUsuarioActualizacion { get; set; }
        [JsonPropertyName("fechaActualizacion")]
        public DateTime FechaActualizacion { get; set; }
    }
}
