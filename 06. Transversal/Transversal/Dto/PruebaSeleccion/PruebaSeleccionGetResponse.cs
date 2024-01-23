#nullable disable

using Domain.Model;

namespace Transversal.Dto
{
    public class PruebaSeleccionGetResponse : BaseResponse
    {
        public List<PruebaSeleccionDto> pruebaSeleccions { get; set; }     
    }
    public class PruebaSeleccionDto
    {
        public int Id { get; set; }
        public string NombreDescripcion { get; set; }
        public int IdTipoPrueba { get; set; }
        public string TipoPrueba { get; set; }
        public int IdLenguajeProgramacion { get; set; }
        public string LenguajeProgramacion { get; set; }
        public int CantidadPreguntas { get; set; }
        public int IdNivel { get; set; }
        public string Nivel { get; set; }
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
