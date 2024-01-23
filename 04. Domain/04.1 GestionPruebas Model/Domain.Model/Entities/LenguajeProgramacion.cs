using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public partial class LenguajeProgramacion
    {
        public LenguajeProgramacion()
        {
            Pregunta = new HashSet<Pregunta>();
            PruebaSeleccions = new HashSet<PruebaSeleccion>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public virtual Usuario IdUsuarioActualizacionNavigation { get; set; } = null!;
        public virtual ICollection<Pregunta> Pregunta { get; set; }
        public virtual ICollection<PruebaSeleccion> PruebaSeleccions { get; set; }
    }
}
