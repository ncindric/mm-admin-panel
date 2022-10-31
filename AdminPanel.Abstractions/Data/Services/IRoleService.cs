using AdminPanel.Abstractions.Data.Models.Roles;

namespace AdminPanel.Abstractions.Data.Services
{
    public interface IRoleService
    {
        IReadOnlyList<RoleDto> Get();
    }
}
