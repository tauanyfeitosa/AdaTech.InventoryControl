using AdaTech.InventoryControl.Entities;
using AdaTech.InventoryControl.Service.Interfaces;
using AdaTech.InventoryControl.Service.Services;
using AdaTech.InventoryControl.WebAPI.Filters;
using AdaTech.InventoryControl.WebAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech.InventoryControl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IInventoryControlService _inventoryControlService;

        public ProductController(ITokenService tokenService, IInventoryControlService inventoryControlService)
        {
            _tokenService = tokenService;
            _inventoryControlService = inventoryControlService;
        }

        [HttpPost("login")]
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

        [HttpPost("logout")]
        [ServiceFilter(typeof(NotLoggedInFilter))]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("JWT");
            return Ok("Usuário deslogado com sucesso!");
        }

        [HttpPost("add")]
        [ServiceFilter(typeof(NotLoggedInFilter))]
        public IActionResult AddProduct([FromBody] ProductRequest request)
        {
            var product = _inventoryControlService.AddProduct(request);
            return View(product);
        }

        [HttpGet("getAll")]
        [ServiceFilter(typeof(NotLoggedInFilter))]
        public IActionResult GetAllProducts()
        {
            var products = _inventoryControlService.GetAllProducts();
            return View(products);
        }

        [HttpGet("getById")]
        [ServiceFilter(typeof(NotLoggedInFilter))]
        public IActionResult GetOneProduct([FromQuery] int id)
        {
            var product = _inventoryControlService.GetOneProduct(id);
            return View(product);
        }

        [HttpPut("update")]
        [ServiceFilter(typeof(NotLoggedInFilter))]
        public IActionResult UpdateProduct([FromBody] ProductRequest request, [FromQuery] int id)
        {
            var product = _inventoryControlService.UpdateProduct(request, id);
            return View(product);
        }

        [HttpDelete("delete")]
        [ServiceFilter(typeof(NotLoggedInFilter))]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            var product = _inventoryControlService.DeleteProduct(id);
            return View(product);
        }

        [HttpPost("registerProductsExit")]
        [ServiceFilter(typeof(NotLoggedInFilter))]
        public IActionResult RegisterProductsExist([FromQuery] int quantity, [FromQuery] int productId, [FromQuery] int? batchId = default)
        {
            _inventoryControlService.RegisterProductsExit(quantity, productId, batchId);
            return View("Products removed successfully!");
        }
    }
}
