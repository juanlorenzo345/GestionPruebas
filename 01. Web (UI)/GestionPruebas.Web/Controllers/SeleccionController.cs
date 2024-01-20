using Microsoft.AspNetCore.Mvc;

namespace GestionPruebas.Web.Controllers
{
    public class SeleccionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}