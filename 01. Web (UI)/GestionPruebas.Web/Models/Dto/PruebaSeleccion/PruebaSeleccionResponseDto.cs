#nullable disable
using System.Text.Json.Serialization;

namespace GestionPruebas.Web.Models.Dto
{
    public class PruebaSeleccionResponseDto
    {
        public List<PruebaSeleccionDto> pruebaSeleccions { get; set;}
    }
    public class PruebaSeleccionDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nombreDescripcion")]
        public string NombreDescripcion { get; set; }
        [JsonPropertyName("idTipoPrueba")]
        public int IdTipoPrueba { get; set; }
        [JsonPropertyName("tipoPrueba")]
        public string TipoPrueba { get; set; }
        [JsonPropertyName("idLenguajeProgramacion")]
        public int IdLenguajeProgramacion { get; set; }
        [JsonPropertyName("lenguajeProgramacion")]
        public string LenguajeProgramacion { get; set; }
        [JsonPropertyName("cantidadPreguntas")]
        public int CantidadPreguntas { get; set; }
        [JsonPropertyName("idNivel")]
        public int IdNivel { get; set; }
        [JsonPropertyName("nivel")]
        public string Nivel { get; set; }
        [JsonPropertyName("estado")]
        public bool Estado { get; set; }
        [JsonPropertyName("idUsuarioActualizacion")]
        public int IdUsuarioActualizacion { get; set; }
        [JsonPropertyName("fechaActualizacion")]
        public DateTime FechaActualizacion { get; set; }
    }
}
