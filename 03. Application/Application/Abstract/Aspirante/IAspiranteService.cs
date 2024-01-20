using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Dto;

namespace Application.Abstract
{
    public interface IAspiranteService
    {
        Task<AspiranteGetResponse> GetAspiranteAsync();
        Task<AspiranteResponse> GetAspiranteByIdAsync(int Id);
        Task<AspiranteResponse> UpdateAsync(AspiranteRequest request);
    }
}
