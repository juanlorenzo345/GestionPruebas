using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public partial class AspirantePruebaSeleccion
    {
        public int Id { get; set; }
        public int IdAspirante { get; set; }
        public int IdPruebaSeleccion { get; set; }
        public decimal? Calificacion { get; set; }
        public int IdEstadoPrueba { get; set; }
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public virtual Aspirante IdAspiranteNavigation { get; set; } = null!;
        public virtual PruebaSeleccion IdPruebaSeleccionNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioActualizacionNavigation { get; set; } = null!;
        public virtual EstadoPrueba IdEstadoPruebaNavigation { get; set; } = null!;
    }
}
