

using Transversal.Dto;

namespace Application.Abstract
{
    public interface IPruebaSeleccionService
    {
        Task<PruebaSeleccionGetResponse> GetPruebaSeleccionAsync();
        Task<PruebaSeleccionResponse> GetPruebaSeleccionByIdAsync(int Id);
        Task<PruebaSeleccionResponse> UpdateAsync(PruebaSeleccionRequest request);
    }
}
