#nullable disable
using Application.Abstract;
using Application.Implements;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Transversal.Dto;
using Microsoft.AspNetCore.Hosting;

namespace GestionPruebas.Api.Controllers
{
    [ApiController]
    public class ReporteController : BaseApiController
    {
        private readonly IReporteService reporteService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReporteController(IReporteService service, IWebHostEnvironment webHostEnvironment) { 
            reporteService = service;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [HttpGet]
        [Route("GetReporteAsync")]
        public async Task<IActionResult> GetReporteAsync()
        {
            var response = await reporteService.GetReporteAsync();

            if (!response.Success)
            {
                return UnprocessableEntity(response);
            }
            ReporteResponseDto filePath = ExportarReporte(response);
            return Ok(filePath);
        }

        private ReporteResponseDto ExportarReporte(ReporteAspiranteGetResponseDto data)
        {
            string directorioProyecto = _webHostEnvironment.ContentRootPath;
            string rutaRelativa = "ArchivosExportados/reporte_aspirantes.txt";
            string rutaCompleta = Path.Combine(directorioProyecto, rutaRelativa);
            Directory.CreateDirectory(Path.GetDirectoryName(rutaCompleta));

            var contenidoArchivo = ConstruirContenidoArchivo(data);
            System.IO.File.WriteAllText(rutaCompleta, contenidoArchivo);
            ReporteResponseDto response = new ReporteResponseDto
            {
                filePath = rutaCompleta,
            };
            return response;
        }

        private string ConstruirContenidoArchivo(ReporteAspiranteGetResponseDto reportes)
        {
            var contenido = new StringBuilder();

            foreach (var reporte in reportes.Reportes)
            {
                contenido.AppendLine($"IdTipoDocumento: {reporte.IdTipoDocumento}, TipoDocumento: {reporte.TipoDocumento}, NumeroDocumento: {reporte.NumeroDocumento}," +
                    $"IdAspirante: {reporte.IdAspirante}, Aspirante: {reporte.Aspirante}, IdPruebaSeleccion: {reporte.IdPruebaSeleccion}, PruebaSeleccion: {reporte.PruebaSeleccion}, " +
                    $"Calificacion: {reporte.Calificacion}, IdEstadoPrueba: {reporte.IdEstadoPrueba}, EstadoPrueba: {reporte.EstadoPrueba}, Direccion: {reporte.Direccion}, " +
                    $"Telefono: {reporte.Telefono}, Estado: {reporte.Estado}, IdUsuarioActualizacion: {reporte.IdUsuarioActualizacion}, UsuarioActualizacion: {reporte.UsuarioActualizacion}, " +
                    $"FechaActualizacion: {reporte.FechaActualizacion}");
            }

            return contenido.ToString();
        }

    }
}
