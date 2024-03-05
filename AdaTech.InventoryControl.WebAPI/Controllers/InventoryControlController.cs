using AdaTech.InventoryControl.Service.Services;
using AdaTech.InventoryControl.WebAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

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

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddHours(1)
            };

            Response.Cookies.Append("JWT", token, cookieOptions);

            return Ok(token);
        }

        [HttpPost("loginSemFiltro")]
        public IActionResult LoginSemFiltro(string email, string password)
        {
            var token = _tokenService.GenerateToken(email, password);
            return Ok(token);
        }

        [HttpPost("logout")]
        [ServiceFilter(typeof(NotLoggedInFilter))]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("JWT");
            return Ok("Usuário deslogado com sucesso!");
        }
    }
}
