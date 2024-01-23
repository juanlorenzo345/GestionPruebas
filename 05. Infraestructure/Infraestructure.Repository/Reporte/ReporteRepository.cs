#nullable disable
using Domain.Model;
using Infraestructure.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Transversal.Dto;

namespace Infraestructure.Repository
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly DBGestionPruebasContext tasksDbContext;

        public ReporteRepository(DBGestionPruebasContext tasksDbContext)
        {
            this.tasksDbContext = tasksDbContext;
        }

        public async Task<ReporteAspiranteGetResponseDto> GetReporteAsync()
        {
            var response = await tasksDbContext.Set<ReporteAspirante>()
            .FromSqlInterpolated($"EXEC dbo.SP_Reporte_Aspirantes_Get")
            .ToListAsync();
            return new ReporteAspiranteGetResponseDto { Success = true, Reportes = response };
        }
    }
}
