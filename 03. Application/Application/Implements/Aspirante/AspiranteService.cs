using Application.Abstract;
using Domain.Model;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Dto;

namespace Application.Implements
{
    public class AspiranteService : IAspiranteService
    {
        private readonly IAspiranteRepository aspiranteRepository;
        public AspiranteService(IAspiranteRepository aspiranteRepository)
        {
            this.aspiranteRepository = aspiranteRepository;
        }
        public async Task<AspiranteGetResponse> GetAspiranteAsync()
        {
            try
            {
                return await aspiranteRepository.GetAspiranteAsync();
            }
            catch (Exception ex)
            {
                return new AspiranteGetResponse
                {
                    Success = false,
                    ErrorCode = "500",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Error = ex.InnerException != null ? ex.Message + ex.InnerException.Message : ex.Message
                };
            }
        }

        public async Task<AspiranteResponse> GetAspiranteByIdAsync(int Id)
        {
            try
            {
                return await aspiranteRepository.GetAspiranteByIdAsync(Id);
            }
            catch (Exception ex)
            {
                return new AspiranteResponse
                {
                    Success = false,
                    ErrorCode = "500",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Error = ex.InnerException != null ? ex.Message + ex.InnerException.Message : ex.Message
                };
            }
        }

        public async Task<AspiranteResponse> UpdateAsync(AspiranteRequest request)
        {
            try
            {
                return await aspiranteRepository.UpdateAsync(request);
            }
            catch (Exception ex)
            {
                return new AspiranteResponse
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
