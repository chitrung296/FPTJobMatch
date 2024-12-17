using System.ComponentModel;

namespace FPTJobMatch.MVC.Models
{
    public class CompanyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Description("Trụ sở Headquarter")]
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Hotline { get; set; }

        public string TaxNumber { get; set; } = string.Empty;

        public int Position { get; set; }
    }
}
