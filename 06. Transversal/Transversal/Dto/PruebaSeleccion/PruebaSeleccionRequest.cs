#nullable disable

namespace Transversal.Dto
{
    public class PruebaSeleccionRequest
    {
        public int Id { get; set; }
        public string NombreDescripcion { get; set; }
        public int IdTipoPrueba { get; set; }
        public int IdLenguajeProgramacion { get; set; }
        public int CantidadPreguntas { get; set; }
        public int IdNivel { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
