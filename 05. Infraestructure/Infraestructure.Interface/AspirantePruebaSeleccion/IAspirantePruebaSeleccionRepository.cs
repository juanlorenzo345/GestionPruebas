#nullable disable

using Transversal.Dto;

namespace Infraestructure.Interface
{
    public interface IAspirantePruebaSeleccionRepository
    {
        Task<AspirantePruebaSeleccionGetResponse> GetAspirantePruebaSeleccionAsync();

        Task<AspirantePruebaSeleccionGetResponse> GetAspirantePruebaSeleccionByIdAsync(int Id);

        Task<AspirantePruebaSeleccionResponse> UpdateAsync(AspirantePruebaSeleccionRequest request);

        Task<AspirantePruebaSeleccionDto> GetAspirantePruebaSeleccionByIdAPAsync(int Id);
    }
}
