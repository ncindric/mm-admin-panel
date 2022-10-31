using AdminPanel.Abstractions.Data.Models.Permissions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminPanel.Web.Models
{
    public class PermissionUpdateViewModel
    {
        public PermissionDto Permission { get; set; } = null!;

        public IReadOnlyList<SelectListItem> Roles { get; set; } = Array.Empty<SelectListItem>();
    }
}
