using AdminPanel.Abstractions.Data.Models.Roles;

namespace AdminPanel.Abstractions.Data.Models.Permissions
{
    public class PermissionDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IReadOnlyList<RoleDto> Roles { get; set; } = Array.Empty<RoleDto>();
    }
}
