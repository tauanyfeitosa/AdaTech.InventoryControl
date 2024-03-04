using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdaTech.InventoryControl.WebAPI.Filters
{
    public class AlreadyLoggedInFilter : IAuthorizationFilter
    {
        private IHttpContextAccessor? _IHttpContextAccessor { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_IHttpContextAccessor!.HttpContext!.Request.Cookies.ContainsKey("JWT")) 
            {
                context.Result = new ContentResult()
                {
                    Content = "Já existe um usuário logado.",
                    StatusCode = 401
                };
            }
        }
        public AlreadyLoggedInFilter(IHttpContextAccessor httpContextAccessor)
        {
            _IHttpContextAccessor = httpContextAccessor;
        }
    }
}
