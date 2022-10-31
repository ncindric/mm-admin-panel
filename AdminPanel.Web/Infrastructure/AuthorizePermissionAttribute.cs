using Microsoft.AspNetCore.Authorization;

namespace AdminPanel.Web.Infrastructure
{
    public sealed class AuthorizePermissionAttribute : Attribute
    {
        public AuthorizePermissionAttribute(string permission)
        {
            Permission = permission;
        }

        public string Permission { get; }
    }
}
