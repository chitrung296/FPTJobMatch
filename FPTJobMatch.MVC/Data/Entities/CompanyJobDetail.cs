using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTJobMatch.MVC.Data.Entities
{
    public class CompanyJobDetail
    {
        public CompanyJobDetail()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Description { get; set; }
        public string? Requirements { get; set; }

        public int Position { get; set; }

        //[Key, Column(Order = 0)]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        //[Key, Column(Order = 1)]
        public Guid JobId { get; set; }
        public Job Job { get; set; }
    }
}
