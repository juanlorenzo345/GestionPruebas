using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Dto;

namespace Infraestructure.Interface
{
    public interface IAspiranteRepository
    {
        Task<AspiranteGetResponse> GetAspiranteAsync();
        Task<AspiranteResponse> GetAspiranteByIdAsync(int Id);
        Task<AspiranteResponse> UpdateAsync(AspiranteRequest request);
    }
}
