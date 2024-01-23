using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public partial class PruebaSeleccion
    {
        public PruebaSeleccion()
        {
            AspirantePruebaSeleccions = new HashSet<AspirantePruebaSeleccion>();
            PreguntasPruebaSeleccions = new HashSet<PreguntasPruebaSeleccion>();
        }

        public int Id { get; set; }
        public string NombreDescripcion { get; set; } = null!;
        public int IdTipoPrueba { get; set; }
        public int IdLenguajeProgramacion { get; set; }
        public int CantidadPreguntas { get; set; }
        public int IdNivel { get; set; }
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public virtual LenguajeProgramacion IdLenguajeProgramacionNavigation { get; set; } = null!;
        public virtual Nivel IdNivelNavigation { get; set; } = null!;
        public virtual TipoPrueba IdTipoPruebaNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioActualizacionNavigation { get; set; } = null!;
        public virtual ICollection<AspirantePruebaSeleccion> AspirantePruebaSeleccions { get; set; }
        public virtual ICollection<PreguntasPruebaSeleccion> PreguntasPruebaSeleccions { get; set; }
    }
}
