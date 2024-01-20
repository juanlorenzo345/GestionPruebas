
#nullable disable

namespace Transversal.Dto
{
    public class UsuarioResponse : BaseResponse
    {
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
