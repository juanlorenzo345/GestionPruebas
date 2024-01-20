#nullable disable
using Domain.Model;
using Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Transversal.Dto;

namespace Infraestructure.Repository
{
    public class AspiranteRepository : IAspiranteRepository
    {
        private readonly DBGestionPruebasContext tasksDbContext;

        public AspiranteRepository(DBGestionPruebasContext tasksDbContext)
        {
            this.tasksDbContext = tasksDbContext;
        }

        public async Task<AspiranteGetResponse> GetAspiranteAsync()
        {
            var response = await tasksDbContext.Aspirantes.ToListAsync();
            return new AspiranteGetResponse { Success = true, Aspirantes = response };
        }

        public async Task<AspiranteResponse> GetAspiranteByIdAsync(int Id)
        {
            var response = await tasksDbContext.Aspirantes.Where(c => c.Id == Id).FirstOrDefaultAsync();
            if (response != null)
            {
                return new AspiranteResponse
                {
                    Success = true,
                    Id = response.Id,
                    IdTipoDocumento = response.IdTipoDocumento,
                    NumeroDocumento = response.NumeroDocumento,
                    Nombre = response.Nombre,
                    Apellido = response.Apellido,
                    Direccion = response.Direccion,
                    Telefono = response.Telefono,
                    IdEstadoPrueba = response.IdEstadoPrueba,
                    Estado = response.Estado,
                    IdUsuarioActualizacion = response.IdUsuarioActualizacion,
                    FechaActualizacion = response.FechaActualizacion
                };
            }
            else
            {
                return new AspiranteResponse
                {
                    Success = false,
                    ErrorCode = "404",
                    StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                    Error = "Aspirante not found: " + Id
                };
            }
        }

        public async Task<AspiranteResponse> UpdateAsync(AspiranteRequest request)
        {
            Aspirante entity = await tasksDbContext.Aspirantes.Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (entity == null)
            {
                Aspirante aspirante = new Aspirante()
                {
                    IdTipoDocumento = request.IdTipoDocumento,
                    NumeroDocumento = request.NumeroDocumento,
                    Nombre  = request.Nombre,
                    Apellido = request.Apellido,
                    Direccion = request.Direccion,
                    Telefono  = request.Telefono,
                    IdEstadoPrueba = request.IdEstadoPrueba,
                    Estado = true,
                    IdUsuarioActualizacion = request.IdUsuarioActualizacion,
                    FechaActualizacion = DateTime.Now,
                 };
                tasksDbContext.Add(aspirante);
            }
            else
            {
                entity.IdTipoDocumento = request.IdTipoDocumento;
                entity.NumeroDocumento = request.NumeroDocumento;
                entity.Nombre = request.Nombre;
                entity.Apellido = request.Apellido;
                entity.Direccion = request.Direccion;
                entity.Telefono = request.Telefono;
                entity.IdEstadoPrueba = request.IdEstadoPrueba;
                entity.Estado = request.Estado;
                entity.IdUsuarioActualizacion = request.IdUsuarioActualizacion;
                entity.FechaActualizacion = DateTime.Now;
            }
            var saveResponse = await tasksDbContext.SaveChangesAsync();
            if (saveResponse <= 0)
            {
                return new AspiranteResponse
                {
                    Success = false,
                    Error = "Unable to save Aspirante",
                    ErrorCode = "T01",
                    StatusCode = System.Net.HttpStatusCode.UnprocessableEntity

                };
            }
            return new AspiranteResponse
            {
                Success = true,
                IdTipoDocumento = request.IdTipoDocumento,
                NumeroDocumento = request.NumeroDocumento,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Direccion = request.Direccion,
                Telefono = request.Telefono,
                IdEstadoPrueba = request.IdEstadoPrueba,
                Estado = request.Estado,
                IdUsuarioActualizacion = request.IdUsuarioActualizacion,
                FechaActualizacion = DateTime.Now,
            };
        }
    }
}
