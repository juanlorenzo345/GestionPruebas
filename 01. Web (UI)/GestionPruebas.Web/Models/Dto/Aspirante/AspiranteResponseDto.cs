#nullable disable

namespace GestionPruebas.Web.Models.Dto
{
    public partial class AspiranteResponseDto
    {
        public int Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdEstadoPrueba { get; set; }
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}