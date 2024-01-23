#nullable disable

using Domain.Model;
using System.Text.Json.Serialization;

namespace Transversal.Dto
{
    public class AspirantePruebaSeleccionGetResponse : BaseResponse
    {
        public List<AspirantePruebaSeleccionDto> AspirantePruebaSeleccions { get; set; }
    }

    public class AspirantePruebaSeleccionDto : BaseResponse
    {
        public int Id { get; set; }
        public int IdAspirante { get; set; }
        public string Aspirante { get; set; }
        public int IdPruebaSeleccion { get; set; }
        public string PruebaSeleccion { get; set; }
        public decimal? Calificacion { get; set; }
        public int IdEstadoPrueba { get; set; }
        public string EstadoPrueba { get; set; }
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}