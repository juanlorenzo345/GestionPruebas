using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public partial class EstadoPrueba
    {
        public EstadoPrueba()
        {
            AspirantePruebaSeleccions = new HashSet<AspirantePruebaSeleccion>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public virtual Usuario IdUsuarioActualizacionNavigation { get; set; } = null!;
        public virtual ICollection<AspirantePruebaSeleccion> AspirantePruebaSeleccions { get; set; }
    }
}
