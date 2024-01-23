using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public partial class PreguntasPruebaSeleccion
    {
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        public int IdPruebaSeleccion { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public virtual Pregunta IdPreguntaNavigation { get; set; } = null!;
        public virtual PruebaSeleccion IdPruebaSeleccionNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioActualizacionNavigation { get; set; } = null!;
    }
}
