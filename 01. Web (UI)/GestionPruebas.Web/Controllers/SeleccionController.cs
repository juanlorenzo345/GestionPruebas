#nullable disable
using GestionPruebas.Web.Helper;
using GestionPruebas.Web.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using X.PagedList;

namespace GestionPruebas.Web.Controllers
{
    public class SeleccionController : Controller
    {
        private readonly ILogger<SeleccionController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public SeleccionController(ILogger<SeleccionController> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _clientFactory = httpClientFactory;
            _configuration = configuration;

        }
        public async Task<IActionResult> Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 30;

            PruebaSeleccionResponseDto model = await GetProcesoSeleccionAsync();
            var pagedList = await model.pruebaSeleccions.ToPagedListAsync(pageNumber, pageSize);

            IPagedList<PruebaSeleccionDto> pagedAspirantes = new StaticPagedList<PruebaSeleccionDto>(pagedList.ToList(), pagedList.GetMetaData());

            return View(pagedAspirantes);
        }

        [HttpGet]
        [Authorize]
        public async Task<PruebaSeleccionResponseDto> GetProcesoSeleccionAsync()
        {
            try
            {
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                var model = new PruebaSeleccionResponseDto();
                var url = "PruebaSeleccion/GetPruebaSeleccionAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<PruebaSeleccionResponseDto>(content);
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
            var pruebaSeleccionDto = await GetPruebaSeleccionByIdAsync(id);
            if (pruebaSeleccionDto == null)
            {
                return NotFound(); 
            }

            return View("Editar", pruebaSeleccionDto);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var pruebaSeleccionDto = await GetPruebaSeleccionByIdAsync(id);
            if (pruebaSeleccionDto == null)
            {
                return NotFound();
            }

            var prueba = await DeleteAsync(pruebaSeleccionDto);
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

        [HttpGet]
        [Authorize]
        private async Task<PruebaSeleccionDto> GetPruebaSeleccionByIdAsync(int id)
        {
            try
            {
                var token = Request.Cookies["Token"];

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                var model = new PruebaSeleccionDto();
                var url = $"PruebaSeleccion/GetPruebaSeleccionByIdAsync/{id}";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<PruebaSeleccionDto>(content);
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

        public async Task<IActionResult> GuardarEdicion(PruebaSeleccionDto pruebaSeleccion)
        {
            var pruebaSeleccionDto = await UpdateAsync(pruebaSeleccion);
            if (pruebaSeleccionDto == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GuardarCreacion(PruebaSeleccionDto pruebaSeleccion)
        {
            var pruebaSeleccionDto = await UpdateAsync(pruebaSeleccion);
            if (pruebaSeleccionDto == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        private async Task<PruebaSeleccionDto> UpdateAsync(PruebaSeleccionDto pruebaSeleccionDto)
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
                var model = new PruebaSeleccionDto();
                pruebaSeleccionDto.IdUsuarioActualizacion  = int.Parse(userId);
                pruebaSeleccionDto.Estado = true;
                var url = $"PruebaSeleccion/UpdateAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var dataObj = JsonSerializer.Serialize(pruebaSeleccionDto);
                    var contentObj = new StringContent(dataObj, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, contentObj);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<PruebaSeleccionDto>(content);
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
        private async Task<PruebaSeleccionDto> DeleteAsync(PruebaSeleccionDto pruebaSeleccionDto)
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
                var model = new PruebaSeleccionDto();
                pruebaSeleccionDto.IdUsuarioActualizacion = int.Parse(userId);
                pruebaSeleccionDto.Estado = false; 
                var url = $"PruebaSeleccion/UpdateAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var dataObj = JsonSerializer.Serialize(pruebaSeleccionDto);
                    var contentObj = new StringContent(dataObj, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, contentObj);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<PruebaSeleccionDto>(content);
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