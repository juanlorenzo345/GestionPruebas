#nullable disable
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using GestionPruebas.Web.Helper;
using GestionPruebas.Web.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;


namespace GestionPruebas.Web.Controllers
{
    public class AspiranteController : Controller
    {
        private readonly ILogger<AspiranteController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public AspiranteController(ILogger<AspiranteController> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _clientFactory = httpClientFactory;
            _configuration = configuration;

        }
        public async Task<IActionResult> Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10; 

            AspiranteResponseDto model = await GetAspirantesAsync();
            var pagedList = await model.aspirantes.ToPagedListAsync(pageNumber, pageSize);

            IPagedList<AspiranteDto> pagedAspirantes = new StaticPagedList<AspiranteDto>(pagedList.ToList(), pagedList.GetMetaData());

            return View(pagedAspirantes);
        }

        [HttpGet]
        [Authorize]
        public async Task<AspiranteResponseDto> GetAspirantesAsync()
        {
            try
            {
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                var model = new AspiranteResponseDto();
                var url = "Aspirante/GetAspiranteAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<AspiranteResponseDto>(content);
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ReporteResponseDto> GetReporteAsync()
        {
            try
            {
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                var model = new ReporteResponseDto();
                var url = "Reporte/GetReporteAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<ReporteResponseDto>(content);
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }


        public async Task<IActionResult> Editar(int id)
        {
            var aspiranteDto = await GetAspiranteByIdAsync(id);
            if (aspiranteDto == null)
            {
                return NotFound();
            }

            return View("Editar", aspiranteDto);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var aspiranteDto = await GetAspiranteByIdAsync(id);
            if (aspiranteDto == null)
            {
                return NotFound();
            }

            var prueba = await DeleteAsync(aspiranteDto);
            if (prueba == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Crear()
        {
            return View("Crear");
        }

        public async Task<IActionResult> ListAsignacionPrueba(int id)
        {
            AspirantePruebaSeleccionResponseDto model = await GetAspirantePruebaSeleccionByIdAsync(id);
            return View("AspirantePrueba", model); 
        }

        public async Task<IActionResult> AsignarPrueba()
        {
            var routeData = this.ControllerContext.RouteData.Values;

            foreach (var item in routeData)
            {
                if (item.Key == "id")
                {
                    int id = Convert.ToInt32(item.Value);
                    var aspiranteDto = await GetAspiranteByIdAsync(id);
                    if (aspiranteDto != null)
                    {
                        return View("AsignarPrueba", aspiranteDto);
                    }
                }
            }
            return NotFound();
        }


        [HttpGet]
        [Authorize]
        private async Task<AspiranteDto> GetAspiranteByIdAsync(int id)
        {
            try
            {
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                var model = new AspiranteDto();
                var url = $"Aspirante/GetAspiranteByIdAsync/{id}";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<AspiranteDto>(content);
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }

        [HttpGet]
        [Authorize]
        private async Task<AspirantePruebaSeleccionResponseDto> GetAspirantePruebaSeleccionByIdAsync(int id)
        {
            try
            {
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                var model = new AspirantePruebaSeleccionResponseDto();
                var url = $"AspirantePruebaSeleccion/GetAspirantePruebaSeleccionByIdAsync/{id}";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<AspirantePruebaSeleccionResponseDto>(content);
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }

        [HttpGet]
        [Authorize]
        private async Task<AspirantePruebaSeleccionDto> GetAspirantePruebaSeleccionByIdAPAsync(int id)
        {
            try
            {
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                var model = new AspirantePruebaSeleccionDto();
                var url = $"AspirantePruebaSeleccion/GetAspirantePruebaSeleccionByIdAPAsync/{id}";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<AspirantePruebaSeleccionDto>(content);
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }

        public async Task<IActionResult> GuardarEdicion(AspiranteDto aspirante)
        {
            var aspiranteDto = await UpdateAsync(aspirante);
            if (aspiranteDto == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GuardarCreacion(AspiranteDto aspirante)
        {
            var aspiranteDto = await UpdateAsync(aspirante);
            if (aspiranteDto == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GuardarAsignarPrueba(AspiranteDto aspirantePrueba)
        {
            var aspiranteDto = await UpdateAspirantePruebaAsync(aspirantePrueba);
            if (aspiranteDto == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditarAsignacion(int id)
        {
            var aspiranteDto = await GetAspirantePruebaSeleccionByIdAPAsync(id);
            if (aspiranteDto == null)
            {
                return NotFound();
            }

            return View("EditarAspirantePrueba", aspiranteDto);
        }

        public async Task<IActionResult> GuardarAsignacion(AspirantePruebaSeleccionDto aspirantePrueba)
        {
            var aspiranteDto = await UpdateEditarAspirantePruebaAsync(aspirantePrueba);
            if (aspiranteDto == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EliminarAsignacion(int id)
        {
            var pruebaSeleccionDto = await GetAspirantePruebaSeleccionByIdAPAsync(id);
            if (pruebaSeleccionDto == null)
            {
                return NotFound();
            }

            var prueba = await DeleteAsignacionAsync(pruebaSeleccionDto);
            if (prueba == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DescargarAspirantes()
        {
            
            var filePath = await GetReporteAsync();
            var contentType = "text/plain";

            return File(System.IO.File.ReadAllBytes(filePath.filePath), contentType, "reporte_aspirantes.txt");
        }


        [HttpPost]
        [Authorize]
        private async Task<AspiranteDto> UpdateAsync(AspiranteDto aspiranteDto)
        {
            try
            {
                UtilToken utilToken = new UtilToken();
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }
                string userId = utilToken.ExtractNameIdFromToken(token);
                var model = new AspiranteDto();
                aspiranteDto.IdUsuarioActualizacion = int.Parse(userId);
                aspiranteDto.Estado = true;
                var url = $"Aspirante/UpdateAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var dataObj = JsonSerializer.Serialize(aspiranteDto);
                    var contentObj = new StringContent(dataObj, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, contentObj);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<AspiranteDto>(content);
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Authorize]
        private async Task<AspiranteDto> DeleteAsync(AspiranteDto aspiranteDto)
        {
            try
            {
                UtilToken utilToken = new UtilToken();
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }
                string userId = utilToken.ExtractNameIdFromToken(token);
                var model = new AspiranteDto();
                aspiranteDto.IdUsuarioActualizacion = int.Parse(userId);
                aspiranteDto.Estado = false;
                var url = $"Aspirante/UpdateAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var dataObj = JsonSerializer.Serialize(aspiranteDto);
                    var contentObj = new StringContent(dataObj, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, contentObj);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<AspiranteDto>(content);
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Authorize]
        private async Task<AspirantePruebaSeleccionDto> UpdateAspirantePruebaAsync(AspiranteDto aspiranteDto)
        {
            try
            {
                
                UtilToken utilToken = new UtilToken();
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }
                string userId = utilToken.ExtractNameIdFromToken(token);
                var model = new AspirantePruebaSeleccionDto();
                AspirantePruebaSeleccionDto request = new AspirantePruebaSeleccionDto
                {
                    IdAspirante = aspiranteDto.Id,  
                    IdPruebaSeleccion = int.Parse(aspiranteDto.aspirantePruebaSeleccionDto.PruebaSeleccion),
                    Calificacion = aspiranteDto.aspirantePruebaSeleccionDto.Calificacion,
                    IdEstadoPrueba = int.Parse(aspiranteDto.aspirantePruebaSeleccionDto.EstadoPrueba),
                    Estado = true,
                    IdUsuarioActualizacion = int.Parse(userId),
                    FechaActualizacion = DateTime.Now,
                };
                var url = $"AspirantePruebaSeleccion/UpdateAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var dataObj = JsonSerializer.Serialize(request);
                    var contentObj = new StringContent(dataObj, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, contentObj);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<AspirantePruebaSeleccionDto>(content);
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Authorize]
        private async Task<AspirantePruebaSeleccionDto> UpdateEditarAspirantePruebaAsync(AspirantePruebaSeleccionDto aspiranteDto)
        {
            try
            {

                UtilToken utilToken = new UtilToken();
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }
                string userId = utilToken.ExtractNameIdFromToken(token);
                var model = new AspirantePruebaSeleccionDto();
                aspiranteDto.IdUsuarioActualizacion = int.Parse(userId);
                aspiranteDto.Estado = true;
                var url = $"AspirantePruebaSeleccion/UpdateAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var dataObj = JsonSerializer.Serialize(aspiranteDto);
                    var contentObj = new StringContent(dataObj, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, contentObj);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<AspirantePruebaSeleccionDto>(content);
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }

        [HttpPost]
        [Authorize]
        private async Task<AspirantePruebaSeleccionDto> DeleteAsignacionAsync(AspirantePruebaSeleccionDto aspiranteDto)
        {
            try
            {
                UtilToken utilToken = new UtilToken();
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }
                string userId = utilToken.ExtractNameIdFromToken(token);
                var model = new AspirantePruebaSeleccionDto();
                aspiranteDto.IdUsuarioActualizacion = int.Parse(userId);
                aspiranteDto.Estado = false;
                var url = $"AspirantePruebaSeleccion/UpdateAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var dataObj = JsonSerializer.Serialize(aspiranteDto);
                    var contentObj = new StringContent(dataObj, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, contentObj);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<AspirantePruebaSeleccionDto>(content);
                        return model;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return null;
            }
        }

    }
}
