using AdminPanel.Abstractions.Core;
using AdminPanel.Abstractions.Data.Services;
using AdminPanel.Shared.Constants;
using AdminPanel.Web.Infrastructure;
using AdminPanel.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminPanel.Web.Controllers
{
    [Route("permissions/{action?}")]
    [AuthorizePermission(PermissionNames.EditPermissions)]
    public class PermissionsController : Controller
    {
        private readonly IPermissionService _permissionService;
        private readonly IRoleService _roleService;

        public PermissionsController(
            IPermissionService permissionService,
            IRoleService roleService)
        {
            _permissionService = permissionService;
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_permissionService.Get());
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var permission = _permissionService.Get(id);
            if (permission == null)
            {
                return NotFound();
            }

            return View(new PermissionUpdateViewModel
            {
                Permission = permission,
                Roles = _roleService.Get().Select(r => new SelectListItem
                {
                    Selected = permission.Roles.Any(p => string.Equals(r.Id, p.Id)),
                    Text = r.Name,
                    Value = r.Id,
                }).ToList(),
            });
        }

        [HttpPost]
        public IActionResult Submit(PermissionPostModel permissionPostModel)
        {
            var permission = _permissionService.Get(permissionPostModel.Id);
            if (permission == null)
            {
                return NotFound();
            }

            var roles = _roleService.Get();
            permission.Roles = roles
                .Where(r => permissionPostModel.Roles.Any(p => string.Equals(r.Id, p)))
                .ToList();
            Result result = _permissionService.Update(permission);
            if (!result.Succeeded)
            {
                ViewBag.ErrorMessage = "Could not update permission";
                return View("Update", new PermissionUpdateViewModel
                {
                    Permission = permission,
                    Roles = roles.Select(r => new SelectListItem
                    {
                        Selected = permission.Roles.Any(p => string.Equals(r.Id, p.Id)),
                        Text = r.Name,
                        Value = r.Id,
                    }).ToList(),
                });
            }

            return RedirectToAction(nameof(Index));
        }
}
}
