using Transversal.Dto;

namespace Infraestructure.Interface
{
    public interface IPruebaSeleccionRepository
    {
        Task<PruebaSeleccionGetResponse> GetPruebaSeleccionAsync();
        Task<PruebaSeleccionResponse> GetPruebaSeleccionByIdAsync(int Id);
        Task<PruebaSeleccionResponse> UpdateAsync(PruebaSeleccionRequest request);
    }
}
