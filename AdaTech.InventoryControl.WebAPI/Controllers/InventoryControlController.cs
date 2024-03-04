using AdaTech.InventoryControl.Service.Services;
using AdaTech.InventoryControl.WebAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech.InventoryControl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryControlController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public InventoryControlController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("loginComFiltro")]
        [ServiceFilter(typeof(AlreadyLoggedInFilter))]
        public IActionResult Login(string email, string password)
        {
            var token = _tokenService.GenerateToken(email, password);
            return Ok(token);
        }

        [HttpPost("loginSemFiltro")]
        public IActionResult LoginSemFiltro(string email, string password)
        {
            var token = _tokenService.GenerateToken(email, password);
            return Ok(token);
        }


    }
}
