#nullable disable
using Application.Abstract;
using Infraestructure.Interface;
using Transversal.Dto;

namespace Application.Implements
{
    public class AspirantePruebaSeleccionService : IAspirantePruebaSeleccionService
    {
        private readonly IAspirantePruebaSeleccionRepository aspirantePruebaSeleccionRepository;
        public AspirantePruebaSeleccionService(IAspirantePruebaSeleccionRepository aspirantePruebaSeleccionRepository)
        {
            this.aspirantePruebaSeleccionRepository = aspirantePruebaSeleccionRepository;
        }

        public async Task<AspirantePruebaSeleccionGetResponse> GetAspirantePruebaSeleccionAsync()
        {
            try
            {
                return await aspirantePruebaSeleccionRepository.GetAspirantePruebaSeleccionAsync();
            }
            catch (Exception ex)
            {
                return new AspirantePruebaSeleccionGetResponse
                {
                    Success = false,
                    ErrorCode = "500",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Error = ex.InnerException != null ? ex.Message + ex.InnerException.Message : ex.Message
                };
            }
        }

        public async Task<AspirantePruebaSeleccionGetResponse> GetAspirantePruebaSeleccionByIdAsync(int Id)
        {
            try
            {
                return await aspirantePruebaSeleccionRepository.GetAspirantePruebaSeleccionByIdAsync(Id);
            }
            catch (Exception ex)
            {
                return new AspirantePruebaSeleccionGetResponse
                {
                    Success = false,
                    ErrorCode = "500",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Error = ex.InnerException != null ? ex.Message + ex.InnerException.Message : ex.Message
                };
            }
        }

        public async Task<AspirantePruebaSeleccionDto> GetAspirantePruebaSeleccionByIdAPAsync(int Id)
        {
            try
            {
                return await aspirantePruebaSeleccionRepository.GetAspirantePruebaSeleccionByIdAPAsync(Id);
            }
            catch (Exception ex)
            {
                return new AspirantePruebaSeleccionDto
                {
                    Success = false,
                    ErrorCode = "500",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Error = ex.InnerException != null ? ex.Message + ex.InnerException.Message : ex.Message
                };
            }
        }

        public async Task<AspirantePruebaSeleccionResponse> UpdateAsync(AspirantePruebaSeleccionRequest request)
        {
            try
            {
                return await aspirantePruebaSeleccionRepository.UpdateAsync(request);
            }
            catch (Exception ex)
            {
                return new AspirantePruebaSeleccionResponse
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
