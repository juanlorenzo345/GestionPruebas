#nullable disable
using GestionPruebas.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace GestionPruebas.Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILogger<LoginController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public LoginController(
            ILogger<LoginController> logger,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _logger = logger;
            _clientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var model = new LoginRequestDto();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> IniciarSesion(LoginRequestDto request)
        {
            var jsonRequest = JsonSerializer.Serialize(request);
            var url = "Usuario/login";

            using (var httpClient = _clientFactory.CreateClient("ApiGestionPruebas"))
            {
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var userResponse = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(userResponse);
                    string token = tokenResponse.AccessToken;
                    Response.Cookies.Append("Token", token);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al iniciar sesión. Por favor, verifica tus credenciales.");
                    return View("Index", request);
                }
            }
        }

        public IActionResult CerrarSesion()
        {
            Response.Cookies.Delete("Token");

            return RedirectToAction("Index", "Login");
        }

    }
}
