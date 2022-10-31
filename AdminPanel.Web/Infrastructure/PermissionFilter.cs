using System.Reflection;
using System.Runtime.CompilerServices;
using AdminPanel.Abstractions.Data.Services;
using AdminPanel.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminPanel.Web.Infrastructure
{
    public class PermissionFilter : IActionFilter
    {
        private readonly IPermissionService _permissionService;

        public PermissionFilter(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor is not ControllerActionDescriptor controllerActionDescriptor)
            {
                return;
            }

            var permissionAttribute = controllerActionDescriptor.MethodInfo
                .GetCustomAttribute<AuthorizePermissionAttribute>();
            
            // fallback to controller attribute if not specified on method
            permissionAttribute ??= controllerActionDescriptor.ControllerTypeInfo
                .GetCustomAttribute<AuthorizePermissionAttribute>();
            if (permissionAttribute == null)
            {
                return;
            }

            var permission = _permissionService.Get()
                .FirstOrDefault(p => string.Equals(p.Name, permissionAttribute.Permission));
            if (permission == null)
            {
                return;
            }

            if (permission.Roles.All(r => !context.HttpContext.User.IsInRole(r.Name)))
            {
                context.Result = context.HttpContext.User.Identity?.IsAuthenticated ?? false
                    ? new ForbidResult()
                    : new ChallengeResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        { }
    }
}
