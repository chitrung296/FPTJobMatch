using FPTJobMatch.MVC.Data;
using FPTJobMatch.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTJobMatch.MVC.ViewComponents
{
    public class JobSeekerListViewComponent: ViewComponent
    {
        private readonly AppDbContext _context;
        public JobSeekerListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var jobSeekers = await _context.JobSeekers
                .OrderBy(c => c.Position)
                .Select(c => new JobSeekerViewModel
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    Name = c.Name,
                    Position = c.Position,
                    Phone = c.Phone,
                    Email = c.Email,
                    Occupation = c.Occupation,
                    Gender = c.Gender,
                    DateOfBirth = c.DateOfBirth,
                })
                .ToListAsync();
            return View(jobSeekers);
        }
    }
}
