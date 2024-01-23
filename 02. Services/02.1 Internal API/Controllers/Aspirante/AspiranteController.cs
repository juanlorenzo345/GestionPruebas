using Application.Abstract;
using Application.Implements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transversal.Dto;

namespace GestionPruebas.Api.Controllers
{
    [ApiController]
    public class AspiranteController : BaseApiController
    {
        private readonly IAspiranteService aspiranteService;
        public AspiranteController(IAspiranteService service) => aspiranteService = service;

        [Authorize]
        [HttpGet]
        [Route("GetAspiranteAsync")]
        public async Task<IActionResult> GetAspiranteAsync()
        {
            var response = await aspiranteService.GetAspiranteAsync();

            if (!response.Success)
            {
                return UnprocessableEntity(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("GetAspiranteByIdAsync/{Id}")]
        public async Task<IActionResult> GetAspiranteByIdAsync(int Id)
        {
            var response = await aspiranteService.GetAspiranteByIdAsync(Id);

            if (!response.Success)
            {
                return UnprocessableEntity(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        [Route("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(AspiranteRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.NumeroDocumento) || string.IsNullOrEmpty(request.Nombre))
            {
                return BadRequest(new AspiranteResponse
                {
                    Error = "Missing aspirante details",
                    ErrorCode = "L01"
                });
            }

            var response = await aspiranteService.UpdateAsync(request);

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