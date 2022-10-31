namespace AdminPanel.Web.Models
{
    public class PermissionPostModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = new();
    }
}
