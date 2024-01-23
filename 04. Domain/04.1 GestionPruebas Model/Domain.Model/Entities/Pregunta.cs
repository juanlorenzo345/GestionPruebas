using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public partial class Pregunta
    {
        public Pregunta()
        {
            PreguntasPruebaSeleccions = new HashSet<PreguntasPruebaSeleccion>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdLenguajeProgramacion { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public virtual LenguajeProgramacion IdLenguajeProgramacionNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioActualizacionNavigation { get; set; } = null!;
        public virtual ICollection<PreguntasPruebaSeleccion> PreguntasPruebaSeleccions { get; set; }
    }
}
