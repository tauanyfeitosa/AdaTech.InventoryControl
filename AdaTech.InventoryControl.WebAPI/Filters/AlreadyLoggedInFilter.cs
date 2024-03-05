using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdaTech.InventoryControl.WebAPI.Filters
{
    public class AlreadyLoggedInFilter : IAuthorizationFilter
    {
        private IHttpContextAccessor? _httpContextAccessor;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var httpContext = _httpContextAccessor?.HttpContext;
            if (httpContext != null && httpContext.Request.Cookies.ContainsKey("JWT"))
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
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
