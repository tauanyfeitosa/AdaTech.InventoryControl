using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using AdaTech.InventoryControl.WebAPI.Filters;

namespace AdaTech.InventoryControl.WebAPI.Filters
{
    public class AddAuthorizationFilters : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasAlreadyLoggedInFilter = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AlreadyLoggedInFilter>()
                .Any();

            var hasNotLoggedInFilter = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<NotLoggedInFilter>()
                .Any();

            if (hasAlreadyLoggedInFilter && hasNotLoggedInFilter)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "JWT token",
                    Required = true
                });
            }
        }
    }
}
