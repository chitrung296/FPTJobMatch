﻿using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FPTJobMatch.MVC.Data.Entities
{
    public class Company
    {
        public Company()
        {
            Id = Guid.NewGuid();
            CompanyJobDetails = new Collection<CompanyJobDetail>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Description("Trụ sở Headquarter")]
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Hotline { get; set; }

        public string TaxNumber { get; set; }

        public int Position { get; set; }

        public ICollection<CompanyJobDetail> CompanyJobDetails { get; set; }
    }
}