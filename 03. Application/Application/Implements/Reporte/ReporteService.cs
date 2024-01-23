#nullable disable

using Application.Abstract;
using Infraestructure.Interface;
using Transversal.Dto;

namespace Application.Implements
{
    public class ReporteService : IReporteService
    {
        private readonly IReporteRepository reporteRepository;
        public ReporteService(IReporteRepository reporteRepository)
        {
            this.reporteRepository = reporteRepository;
        }

        public async Task<ReporteAspiranteGetResponseDto> GetReporteAsync()
        {
            try
            {
                return await reporteRepository.GetReporteAsync();
            }
            catch (Exception ex)
            {
                return new ReporteAspiranteGetResponseDto
                {
                    Success = false,
                    ErrorCode = "500",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Error = ex.InnerException != null ? ex.Message + ex.InnerException.Message : ex.Message
                };
            }
        }

    }
}
