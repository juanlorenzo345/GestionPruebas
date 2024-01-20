#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Transversal.Dto
{
    public class SignupRequest
    {
        [Required]
        public string NombreUsuario { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool Estado { get; set; }
        public int IdUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
