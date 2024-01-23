#nullable disable

using Transversal.Dto;

namespace Application.Abstract
{
    public interface IReporteService
    {
        Task<ReporteAspiranteGetResponseDto> GetReporteAsync();
    }
}
