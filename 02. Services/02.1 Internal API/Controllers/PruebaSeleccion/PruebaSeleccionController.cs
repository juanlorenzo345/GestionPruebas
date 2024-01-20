using Application.Abstract;
using Application.Implements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto;

namespace GestionPruebas.Api.Controllers
{
    public class PruebaSeleccionController : BaseApiController
    {
        private readonly IPruebaSeleccionService pruebaSeleccionService;
        public PruebaSeleccionController(IPruebaSeleccionService service) => pruebaSeleccionService = service;

        [Authorize]
        [HttpGet]
        [Route("GetPruebaSeleccionAsync")]
        public async Task<IActionResult> GetPruebaSeleccionAsync()
        {
            var response = await pruebaSeleccionService.GetPruebaSeleccionAsync();

            if (!response.Success)
            {
                return UnprocessableEntity(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("GetPruebaSeleccionByIdAsync/{Id}")]
        public async Task<IActionResult> GetPruebaSeleccionByIdAsync(int Id)
        {
            var response = await pruebaSeleccionService.GetPruebaSeleccionByIdAsync(Id);

            if (!response.Success)
            {
                return UnprocessableEntity(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(PruebaSeleccionRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.NombreDescripcion))
            {
                return BadRequest(new PruebaSeleccionResponse
                {
                    Error = "Missing PruebaSeleccion details",
                    ErrorCode = "L01"
                });
            }

            var response = await pruebaSeleccionService.UpdateAsync(request);

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
