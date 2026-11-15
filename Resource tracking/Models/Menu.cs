namespace Resource_tracking.Models
{
    public class Menu_params
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlPath { get; set; }
        public int ProjectId { get; set; }

        public bool IsDefault { get; set; }
    }
}
