using System.Collections;

namespace AdminPanel.Shared.Constants
{
    public static class RoleNames
    {
        public const string Administrator = "Administrator";
        public const string Editor = "Editor";

        public static readonly IReadOnlyList<string> AllRoles = new List<string>
        {
            Administrator,
        };
    }
}
