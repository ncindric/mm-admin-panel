using AdminPanel.Abstractions.Core;
using AdminPanel.Abstractions.Data.Models.Permissions;

namespace AdminPanel.Abstractions.Data.Services
{
    public interface IPermissionService
    {
        IReadOnlyList<PermissionDto> Get();

        Result Update(PermissionDto permission);
    }
}
