#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GestionPruebas.Web.Models.Dto
{
    public class AspiranteResponseDto
    {
        public List<AspiranteDto> aspirantes { get; set; }
    }

    public class AspiranteDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("idTipoDocumento")]
        public int IdTipoDocumento { get; set; }
        [JsonPropertyName("numeroDocumento")]
        public string NumeroDocumento { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("apellido")]
        public string Apellido { get; set; }
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }
        [JsonPropertyName("idEstadoPrueba")]
        public int IdEstadoPrueba { get; set; }
        [JsonPropertyName("estado")]
        public bool Estado { get; set; }
        [JsonPropertyName("idUsuarioActualizacion")]
        public int IdUsuarioActualizacion { get; set; }
        [JsonPropertyName("fechaActualizacion")]
        public DateTime FechaActualizacion { get; set; }
        [JsonPropertyName("idEstadoPruebaNavigation")]
        public object IdEstadoPruebaNavigation { get; set; }
        [JsonPropertyName("idTipoDocumentoNavigation")]
        public object IdTipoDocumentoNavigation { get; set; }
        [JsonPropertyName("idUsuarioActualizacionNavigation")]
        public object IdUsuarioActualizacionNavigation { get; set; }
        [JsonPropertyName("aspirantePruebaSeleccions")]
        public List<object> AspirantePruebaSeleccions { get; set; }

        public AspirantePruebaSeleccionDto aspirantePruebaSeleccionDto { get; set; }
    }

    

}