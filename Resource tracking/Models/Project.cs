using Microsoft.AspNetCore.Mvc;

namespace Resource_tracking.Models
{
    public class Project_params
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? ImagePath { get; set; }
    }
}
