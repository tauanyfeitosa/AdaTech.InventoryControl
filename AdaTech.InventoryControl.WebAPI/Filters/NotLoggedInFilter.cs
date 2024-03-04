using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdaTech.InventoryControl.WebAPI.Filters
{
    public class NotLoggedInFilter : IAuthorizationFilter
    {
        private IHttpContextAccessor? _HttpContextAccessor { get; set; }

        public NotLoggedInFilter(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_HttpContextAccessor!.HttpContext!.Request.Cookies.ContainsKey("JWT"))
            {
                context.Result = new ContentResult()
                {
                    Content = "Usuário precisa estar logado.",
                    StatusCode = 401
                };
            }
        }
    }
}
