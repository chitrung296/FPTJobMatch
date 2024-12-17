using System.Collections.ObjectModel;

namespace FPTJobMatch.MVC.Data.Entities
{
    public class Job
    {
        public Job()
        {
            Id = Guid.NewGuid();
            CompanyJobDetails = new Collection<CompanyJobDetail>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; } 
        public string Location { get; set; } 
        public string Description { get; set; }
        public string? Requirements { get; set; }
        public string? ImagePath { get; set; } 
        public int Position { get; set; } 
        public Guid JobCategoryId { get; set; }
        public virtual JobCategory JobCategory { get; set; }

        public ICollection<CompanyJobDetail> CompanyJobDetails { get; set; }
        
    }
}