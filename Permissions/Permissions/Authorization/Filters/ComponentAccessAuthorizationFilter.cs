using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Permissions.Authorization.Requirements;



namespace Permissions.Authorization.Filters
{


    /// <summary>
    /// Фильтр авторизации. Исключительно для контроллеров и их методов
    /// </summary>
    public class ComponentAccessAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly int _componentCode;
        private readonly int _permissionCode;



        public ComponentAccessAuthorizationFilter(int componentCode, int permissionCode)
        {
            _componentCode = componentCode;
            _permissionCode = permissionCode;
        }



        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.HasClaim(_componentCode.ToString(), _permissionCode.ToString()))
            {
                context.Result = new ForbidResult();
            }
        }
    }



}