#nullable disable
using Domain.Model;
using Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;
using Transversal.Dto;

namespace Infraestructure.Repository
{
    public class PruebaSeleccionRepository : IPruebaSeleccionRepository
    {
        private readonly DBGestionPruebasContext tasksDbContext;

        public PruebaSeleccionRepository(DBGestionPruebasContext tasksDbContext)
        {
            this.tasksDbContext = tasksDbContext;
        }
        public async Task<PruebaSeleccionGetResponse> GetPruebaSeleccionAsync()
        {
            var response = await tasksDbContext.PruebaSeleccions
            .Where(p => p.Estado)
            .Include(p => p.IdTipoPruebaNavigation)
            .Include(p => p.IdLenguajeProgramacionNavigation)
            .Include(p => p.IdNivelNavigation)
            .OrderByDescending(p => p.FechaActualizacion)
            .Select(p => new PruebaSeleccionDto
            {
                Id = p.Id,
                NombreDescripcion = p.NombreDescripcion,
                IdTipoPrueba = p.IdTipoPrueba,
                TipoPrueba= p.IdTipoPruebaNavigation.Descripcion, 
                IdLenguajeProgramacion = p.IdLenguajeProgramacion,
                LenguajeProgramacion = p.IdLenguajeProgramacionNavigation.Descripcion, 
                CantidadPreguntas = p.CantidadPreguntas,
                IdNivel = p.IdNivel,
                Nivel = p.IdNivelNavigation.Descripcion, 
                IdUsuarioActualizacion = p.IdUsuarioActualizacion,
                FechaActualizacion = p.FechaActualizacion
            })
            .ToListAsync();

            return new PruebaSeleccionGetResponse { Success = true, pruebaSeleccions = response };
        }

        public async Task<PruebaSeleccionResponse> GetPruebaSeleccionByIdAsync(int Id)
        {
            var response = await tasksDbContext.PruebaSeleccions.Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (response != null)
            {
                return new PruebaSeleccionResponse
                {
                    Success = true,
                    Id = response.Id,
                    NombreDescripcion = response.NombreDescripcion,
                    IdTipoPrueba = response.IdTipoPrueba,
                    IdLenguajeProgramacion = response.IdLenguajeProgramacion,
                    CantidadPreguntas = response.CantidadPreguntas,
                    IdNivel = response.IdNivel,
                    Estado = response.Estado,
                    IdUsuarioActualizacion = response.IdUsuarioActualizacion,
                    FechaActualizacion = response.FechaActualizacion
                };
            }
            else
            {
                return new PruebaSeleccionResponse
                {
                    Success = false,
                    ErrorCode = "404",
                    StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                    Error = "Aspirante not found: " + Id
                };
            }
        }

        public async Task<PruebaSeleccionResponse> UpdateAsync(PruebaSeleccionRequest request)
        {
            PruebaSeleccion entity = await tasksDbContext.PruebaSeleccions.Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (entity == null)
            {
                PruebaSeleccion pruebaSeleccion = new PruebaSeleccion()
                {
                    NombreDescripcion = request.NombreDescripcion,
                    IdTipoPrueba = request.IdTipoPrueba,
                    IdLenguajeProgramacion = request.IdLenguajeProgramacion,
                    CantidadPreguntas = request.CantidadPreguntas,
                    Estado = true,
                    IdNivel = request.IdNivel,
                    IdUsuarioActualizacion = request.IdUsuarioActualizacion,
                    FechaActualizacion = DateTime.Now,
                };
                tasksDbContext.Add(pruebaSeleccion);
            }
            else
            {
                entity.NombreDescripcion = request.NombreDescripcion;
                entity.IdTipoPrueba = request.IdTipoPrueba;
                entity.IdLenguajeProgramacion= request.IdLenguajeProgramacion;
                entity.CantidadPreguntas = request.CantidadPreguntas;
                entity.Estado = request.Estado;
                entity.IdNivel = request.IdNivel;
                entity.IdUsuarioActualizacion = request.IdUsuarioActualizacion;
                entity.FechaActualizacion = DateTime.Now;
            }
            var saveResponse = await tasksDbContext.SaveChangesAsync();
            if (saveResponse <= 0)
            {
                return new PruebaSeleccionResponse
                {
                    Success = false,
                    Error = "Unable to save PruebaSeleccion",
                    ErrorCode = "T01",
                    StatusCode = System.Net.HttpStatusCode.UnprocessableEntity

                };
            }
            return new PruebaSeleccionResponse
            {
                Success = true,
                NombreDescripcion = request.NombreDescripcion,
                IdTipoPrueba = request.IdTipoPrueba,
                IdLenguajeProgramacion = request.IdLenguajeProgramacion,
                CantidadPreguntas = request.CantidadPreguntas,
                Estado= request.Estado,
                IdNivel = request.IdNivel,
                IdUsuarioActualizacion = request.IdUsuarioActualizacion,
                FechaActualizacion = DateTime.Now,
            };
        }

    }
}
