#nullable disable
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Transversal;

namespace GestionPruebas.Api
{
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected int UserID => int.Parse(FindClaim(ClaimTypes.NameIdentifier));
        private string FindClaim(string claimName)
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.FindFirst(claimName);
            if (claim == null)
            {
                return null;
            }
            return claim.Value;
        }
        protected IActionResult ProcessResponse(BaseResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    {
                        return Ok(response);
                    }
                case HttpStatusCode.Created:
                    {
                        return Created(string.Empty, response);
                    }
                case HttpStatusCode.InternalServerError:
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, response);
                    }
                case HttpStatusCode.UnprocessableEntity:
                    {
                        return UnprocessableEntity(response);
                    }
                case HttpStatusCode.Unauthorized:
                    {
                        return Unauthorized();
                    }
                default:
                    {
                        return BadRequest(response);
                    }
            }
        }
    }
}
