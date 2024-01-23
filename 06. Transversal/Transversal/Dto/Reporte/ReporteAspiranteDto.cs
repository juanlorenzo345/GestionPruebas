#nullable disable
namespace Transversal.Dto
{

    public class ReporteAspiranteDto : BaseResponse
    {
        public int idTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int IdAspirante { get; set; }
        public string Aspirante { get; set; }
        public int IdPruebaSeleccion { get; set; }
        public string PruebaSeleccion { get; set; }
        public decimal? Calificacion { get; set; }
        public int IdEstadoPrueba { get; set; }
        public string EstadoPrueba { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
