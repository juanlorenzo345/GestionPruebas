#nullable disable
using Transversal.Dto;

namespace Application.Abstract
{
    public interface IAspirantePruebaSeleccionService
    {
        Task<AspirantePruebaSeleccionGetResponse> GetAspirantePruebaSeleccionAsync();

        Task<AspirantePruebaSeleccionGetResponse> GetAspirantePruebaSeleccionByIdAsync(int Id);

        Task<AspirantePruebaSeleccionResponse> UpdateAsync(AspirantePruebaSeleccionRequest request);

        Task<AspirantePruebaSeleccionDto> GetAspirantePruebaSeleccionByIdAPAsync(int Id);
    }
}
