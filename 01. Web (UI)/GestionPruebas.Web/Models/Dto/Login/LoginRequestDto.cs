#nullable disable
using System.ComponentModel.DataAnnotations;

namespace GestionPruebas.Web.Models
{ 
    public class LoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
