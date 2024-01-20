#nullable disable
using Domain.Model;


namespace Transversal.Dto
{
    public class AspiranteGetResponse : BaseResponse
    {
        public List<Aspirante> Aspirantes { get; set; }
    }
}
