#nullable disable

using Domain.Model;
using Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;
using Transversal.Dto;

namespace Infraestructure.Repository
{
    public class AspirantePruebaSeleccionRepository : IAspirantePruebaSeleccionRepository
    {
        private readonly DBGestionPruebasContext tasksDbContext;

        public AspirantePruebaSeleccionRepository(DBGestionPruebasContext tasksDbContext)
        {
            this.tasksDbContext = tasksDbContext;
        }

        public async Task<AspirantePruebaSeleccionGetResponse> GetAspirantePruebaSeleccionAsync()
        {
            var response = await tasksDbContext.AspirantePruebaSeleccions
             .Where(p => p.Estado)
             .Include(p => p.IdAspiranteNavigation)
             .Include(p => p.IdEstadoPruebaNavigation)
             .Include(p => p.IdPruebaSeleccionNavigation)
             .OrderByDescending(p => p.FechaActualizacion)
             .Select(p => new AspirantePruebaSeleccionDto
             {
                 Id = p.Id,
                 IdAspirante = p.IdAspirante,
                 Aspirante = p.IdAspiranteNavigation.Nombre + " " + p.IdAspiranteNavigation.Apellido,
                 IdPruebaSeleccion = p.IdPruebaSeleccion,
                 PruebaSeleccion = p.IdPruebaSeleccionNavigation.NombreDescripcion,
                 Calificacion = p.Calificacion,
                 IdEstadoPrueba = p.IdEstadoPrueba,
                 EstadoPrueba = p.IdEstadoPruebaNavigation.Descripcion,
                 Estado = p.Estado,
                 IdUsuarioActualizacion = p.IdUsuarioActualizacion,
                 FechaActualizacion = p.FechaActualizacion
             }).ToListAsync();

            return new AspirantePruebaSeleccionGetResponse { Success = true, AspirantePruebaSeleccions = response };
        }

        public async Task<AspirantePruebaSeleccionGetResponse> GetAspirantePruebaSeleccionByIdAsync(int Id)
        {
            var response = await tasksDbContext.AspirantePruebaSeleccions
             .Where(p => p.IdAspirante == Id && p.Estado)
             .Include(p => p.IdAspiranteNavigation)
             .Include(p => p.IdEstadoPruebaNavigation)
             .Include(p => p.IdPruebaSeleccionNavigation)
             .OrderByDescending(p => p.FechaActualizacion)
             .Select(p => new AspirantePruebaSeleccionDto
             {
                 Id = p.Id,
                 IdAspirante = p.IdAspirante,
                 Aspirante = p.IdAspiranteNavigation.Nombre + " " + p.IdAspiranteNavigation.Apellido,
                 IdPruebaSeleccion = p.IdPruebaSeleccion,
                 PruebaSeleccion = p.IdPruebaSeleccionNavigation.NombreDescripcion,
                 Calificacion = p.Calificacion,
                 IdEstadoPrueba = p.IdEstadoPrueba,
                 EstadoPrueba = p.IdEstadoPruebaNavigation.Descripcion,
                 Estado = p.Estado,
                 IdUsuarioActualizacion = p.IdUsuarioActualizacion,
                 FechaActualizacion = p.FechaActualizacion
             }).ToListAsync();

            return new AspirantePruebaSeleccionGetResponse { Success = true, AspirantePruebaSeleccions = response };
        }

        public async Task<AspirantePruebaSeleccionDto> GetAspirantePruebaSeleccionByIdAPAsync(int Id)
        {
            var response = await tasksDbContext.AspirantePruebaSeleccions
             .Where(p => p.Id == Id && p.Estado)
             .Include(p => p.IdAspiranteNavigation)
             .Include(p => p.IdEstadoPruebaNavigation)
             .Include(p => p.IdPruebaSeleccionNavigation)
             .OrderByDescending(p => p.FechaActualizacion)
             .Select(p => new AspirantePruebaSeleccionDto
             {
                 Id = p.Id,
                 IdAspirante = p.IdAspirante,
                 Aspirante = p.IdAspiranteNavigation.Nombre + " " + p.IdAspiranteNavigation.Apellido,
                 IdPruebaSeleccion = p.IdPruebaSeleccion,
                 PruebaSeleccion = p.IdPruebaSeleccionNavigation.NombreDescripcion,
                 Calificacion = p.Calificacion,
                 IdEstadoPrueba = p.IdEstadoPrueba,
                 EstadoPrueba = p.IdEstadoPruebaNavigation.Descripcion,
                 Estado = p.Estado,
                 IdUsuarioActualizacion = p.IdUsuarioActualizacion,
                 FechaActualizacion = p.FechaActualizacion
             }).FirstOrDefaultAsync();

            if (response != null)
            {
                return new AspirantePruebaSeleccionDto
                {
                    Success = true,
                    Id = response.Id,
                    IdAspirante = response.IdAspirante,
                    Aspirante = response.Aspirante,
                    IdPruebaSeleccion = response.IdPruebaSeleccion,
                    PruebaSeleccion = response.PruebaSeleccion,
                    Calificacion = response.Calificacion,
                    IdEstadoPrueba = response.IdEstadoPrueba,
                    Estado = response.Estado,
                    IdUsuarioActualizacion = response.IdUsuarioActualizacion,
                    FechaActualizacion = response.FechaActualizacion
                };
            }
            else
            {
                return new AspirantePruebaSeleccionDto
                {
                    Success = false,
                    ErrorCode = "404",
                    StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                    Error = "Aspirante not found: " + Id
                };
            }
        }

        public async Task<AspirantePruebaSeleccionResponse> UpdateAsync(AspirantePruebaSeleccionRequest request)
        {
            AspirantePruebaSeleccion entity = await tasksDbContext.AspirantePruebaSeleccions.Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (entity == null)
            {
                AspirantePruebaSeleccion aspirantePruebaSeleccion = new AspirantePruebaSeleccion()
                {
                    IdAspirante = request.IdAspirante,
                    IdPruebaSeleccion = request.IdPruebaSeleccion,
                    Calificacion = request.Calificacion,
                    IdEstadoPrueba = request.IdEstadoPrueba,
                    Estado = true,
                    IdUsuarioActualizacion = request.IdUsuarioActualizacion,
                    FechaActualizacion = DateTime.Now,
                };
                tasksDbContext.Add(aspirantePruebaSeleccion);
            }
            else
            {
                entity.IdAspirante = request.IdAspirante;
                entity.IdPruebaSeleccion = request.IdPruebaSeleccion;
                entity.Calificacion = request.Calificacion;
                entity.IdEstadoPrueba = request.IdEstadoPrueba;
                entity.Estado = request.Estado;
                entity.IdUsuarioActualizacion = request.IdUsuarioActualizacion;
                entity.FechaActualizacion = DateTime.Now;
            }
            var saveResponse = await tasksDbContext.SaveChangesAsync();
            if (saveResponse <= 0)
            {
                return new AspirantePruebaSeleccionResponse
                {
                    Success = false,
                    Error = "Unable to save Asignación",
                    ErrorCode = "T01",
                    StatusCode = System.Net.HttpStatusCode.UnprocessableEntity

                };
            }
            return new AspirantePruebaSeleccionResponse
            {
                Success = true,
                IdAspirante = request.IdAspirante,
                IdPruebaSeleccion = request.IdPruebaSeleccion,
                Calificacion = request.Calificacion,
                IdEstadoPrueba = request.IdEstadoPrueba,
                Estado = true,
                IdUsuarioActualizacion = request.IdUsuarioActualizacion,
                FechaActualizacion = DateTime.Now,
            };
        }
    }
}
