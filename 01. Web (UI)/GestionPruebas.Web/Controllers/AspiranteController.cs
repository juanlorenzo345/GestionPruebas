using System.Text.Json;
using GestionPruebas.Web.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

            List<AspiranteResponseDto>? model = await GetAspirantesAsync();

            IPagedList<AspiranteResponseDto> pagedList = model.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        [HttpGet]
        [Authorize]
        public async Task<List<AspiranteResponseDto>?> GetAspirantesAsync()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
                var model = new List<AspiranteResponseDto>();
                var url = $"Aspirante/GetAspiranteAsync";

                using (var client = _clientFactory.CreateClient("ApiGestionPruebas"))
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        model = JsonSerializer.Deserialize<List<AspiranteResponseDto>>(content);
                        return model;
                    }
                }
            }
            catch (System.Exception)
            {

            }
            return null;
        }
    }
}
