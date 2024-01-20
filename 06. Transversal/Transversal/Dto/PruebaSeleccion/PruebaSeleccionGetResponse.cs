#nullable disable

using Domain.Model;

namespace Transversal.Dto
{
    public class PruebaSeleccionGetResponse : BaseResponse
    {
        public List<Domain.Model.PruebaSeleccion> pruebaSeleccions { get; set; }     
    }
}
