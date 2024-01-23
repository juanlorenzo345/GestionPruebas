using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public partial class Usuario
    {
        public Usuario()
        {
            AspirantePruebaSeleccions = new HashSet<AspirantePruebaSeleccion>();
            Aspirantes = new HashSet<Aspirante>();
            EstadoPruebas = new HashSet<EstadoPrueba>();
            InverseIdUsuarioActualizacionNavigation = new HashSet<Usuario>();
            LenguajeProgramacions = new HashSet<LenguajeProgramacion>();
            Nivels = new HashSet<Nivel>();
            Pregunta = new HashSet<Pregunta>();
            PreguntasPruebaSeleccions = new HashSet<PreguntasPruebaSeleccion>();
            PruebaSeleccions = new HashSet<PruebaSeleccion>();
            TipoDocumentos = new HashSet<TipoDocumento>();
            TipoPruebas = new HashSet<TipoPrueba>();
        }

        public int Id { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PasswordHash { get; set; }
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public virtual Usuario IdUsuarioActualizacionNavigation { get; set; } = null!;
        public virtual ICollection<AspirantePruebaSeleccion> AspirantePruebaSeleccions { get; set; }
        public virtual ICollection<Aspirante> Aspirantes { get; set; }
        public virtual ICollection<EstadoPrueba> EstadoPruebas { get; set; }
        public virtual ICollection<Usuario> InverseIdUsuarioActualizacionNavigation { get; set; }
        public virtual ICollection<LenguajeProgramacion> LenguajeProgramacions { get; set; }
        public virtual ICollection<Nivel> Nivels { get; set; }
        public virtual ICollection<Pregunta> Pregunta { get; set; }
        public virtual ICollection<PreguntasPruebaSeleccion> PreguntasPruebaSeleccions { get; set; }
        public virtual ICollection<PruebaSeleccion> PruebaSeleccions { get; set; }
        public virtual ICollection<TipoDocumento> TipoDocumentos { get; set; }
        public virtual ICollection<TipoPrueba> TipoPruebas { get; set; }
    }
}
