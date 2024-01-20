
using Application.Abstract;
using Infraestructure.Interface;
using Transversal.Dto;

namespace Application.Implements
{
    public class PruebaSeleccionService : IPruebaSeleccionService
    {
        private readonly IPruebaSeleccionRepository pruebaSeleccionRepository;
        public PruebaSeleccionService(IPruebaSeleccionRepository pruebaSeleccionRepository)
        {
            this.pruebaSeleccionRepository = pruebaSeleccionRepository;
        }

        public async Task<PruebaSeleccionGetResponse> GetPruebaSeleccionAsync()
        {
            try
            {
                return await pruebaSeleccionRepository.GetPruebaSeleccionAsync();
            }
            catch (Exception ex)
            {
                return new PruebaSeleccionGetResponse
                {
                    Success = false,
                    ErrorCode = "500",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Error = ex.InnerException != null ? ex.Message + ex.InnerException.Message : ex.Message
                };
            }
        }

        public async Task<PruebaSeleccionResponse> GetPruebaSeleccionByIdAsync(int Id)
        {
            try
            {
                return await pruebaSeleccionRepository.GetPruebaSeleccionByIdAsync(Id);
            }
            catch (Exception ex)
            {
                return new PruebaSeleccionResponse
                {
                    Success = false,
                    ErrorCode = "500",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Error = ex.InnerException != null ? ex.Message + ex.InnerException.Message : ex.Message
                };
            }
        }

        public async Task<PruebaSeleccionResponse> UpdateAsync(PruebaSeleccionRequest request)
        {
            try
            {
                return await pruebaSeleccionRepository.UpdateAsync(request);
            }
            catch (Exception ex)
            {
                return new PruebaSeleccionResponse
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
