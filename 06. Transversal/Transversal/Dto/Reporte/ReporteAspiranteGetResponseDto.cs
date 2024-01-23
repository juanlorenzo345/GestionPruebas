#nullable disable
using Domain.Model;

namespace Transversal.Dto
{
    public class ReporteAspiranteGetResponseDto : BaseResponse
    {
        public List<ReporteAspirante> Reportes { get; set; }
    }
}
