#nullable disable

using Transversal.Dto;

namespace Infraestructure.Interface
{
    public interface IReporteRepository
    {
        Task<ReporteAspiranteGetResponseDto> GetReporteAsync();
    }
}
