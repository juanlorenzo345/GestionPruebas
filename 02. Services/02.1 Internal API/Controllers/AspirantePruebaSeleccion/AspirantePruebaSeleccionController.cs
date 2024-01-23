using Application.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto;

namespace GestionPruebas.Api.Controllers
{
    [ApiController]
    public class AspirantePruebaSeleccionController : BaseApiController
    {
        private readonly IAspirantePruebaSeleccionService aspirantePruebaSeleccionService;
        public AspirantePruebaSeleccionController(IAspirantePruebaSeleccionService service) => aspirantePruebaSeleccionService = service;

        [Authorize]
        [HttpGet]
        [Route("GetAspirantePruebaSeleccionAsync")]
        public async Task<IActionResult> GetAspirantePruebaSeleccionAsync()
        {
            var response = await aspirantePruebaSeleccionService.GetAspirantePruebaSeleccionAsync();

            if (!response.Success)
            {
                return UnprocessableEntity(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("GetAspirantePruebaSeleccionByIdAsync/{Id}")]
        public async Task<IActionResult> GetAspirantePruebaSeleccionByIdAsync(int Id)
        {
            var response = await aspirantePruebaSeleccionService.GetAspirantePruebaSeleccionByIdAsync(Id);

            if (!response.Success)
            {
                return UnprocessableEntity(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("GetAspirantePruebaSeleccionByIdAPAsync/{Id}")]
        public async Task<IActionResult> GetAspirantePruebaSeleccionByIdAPAsync(int Id)
        {
            var response = await aspirantePruebaSeleccionService.GetAspirantePruebaSeleccionByIdAPAsync(Id);

            if (!response.Success)
            {
                return UnprocessableEntity(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(AspirantePruebaSeleccionRequest request)
        {
            if (request == null)
            {
                return BadRequest(new AspirantePruebaSeleccionResponse
                {
                    Error = "Missing aspirante details",
                    ErrorCode = "L01"
                });
            }

            var response = await aspirantePruebaSeleccionService.UpdateAsync(request);

            if (!response.Success)
            {
                return Unauthorized(new
                {
                    response.ErrorCode,
                    response.Error
                });
            }

            return Ok(response);
        }

    }
}