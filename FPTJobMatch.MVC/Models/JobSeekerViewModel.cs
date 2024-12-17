using FPTJobMatch.MVC.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FPTJobMatch.MVC.Models
{
    [Bind("Id, FullName, DateOfBirth, Gender, Occupation, Email, Phone")]
    public class JobSeekerViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public int Position { get; set; }

        public OccupationEnum Occupation { get; set; }
    }
}
