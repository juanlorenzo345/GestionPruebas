using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.Dto
{
    public class PruebaSeleccionResponse : BaseResponse
    {
        public int Id { get; set; }
        public string NombreDescripcion { get; set; } = null!;
        public int IdTipoPrueba { get; set; }
        public int IdLenguajeProgramacion { get; set; }
        public int CantidadPreguntas { get; set; }
        public int IdNivel { get; set; }
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
