#nullable disable
namespace Transversal.Dto
{
    public class AspirantePruebaSeleccionResponse : BaseResponse
    {
        public int Id { get; set; }
        public int IdAspirante { get; set; }
        public int IdPruebaSeleccion { get; set; }
        public decimal? Calificacion { get; set; }
        public int IdEstadoPrueba { get; set; }
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
