using Microsoft.AspNetCore.Mvc;

namespace FPTJobMatch.MVC.Models
{
    [Bind("Id, Name, CompanyName, Location, Image, Description, Requirements, JobCategoryId")]
    public class JobViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Requirements { get; set; }
        public Guid JobCategoryId { get; set; }
        public string? ImagePath { get; internal set; }
        public string JobCategory { get; set; } = string.Empty;
    }
}
