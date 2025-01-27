﻿namespace FPTJobMatch.MVC.Models
{
    public class JobCategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Position { get; set; }
    }
}
