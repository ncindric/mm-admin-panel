namespace AdminPanel.Shared.Constants
{
    public static class PermissionNames
    {
        public const string EditPermissions = "permissions:edit";

        public static readonly IReadOnlyList<string> AllPermissions = new List<string>
        {
            EditPermissions,
        };
    }
}