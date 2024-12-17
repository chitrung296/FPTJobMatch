using FPTJobMatch.MVC.Data;
using FPTJobMatch.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTJobMatch.MVC.ViewComponents
{
    public class JobListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public JobListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool isForHome = false)
        {
            var items = await _context!.Jobs!
                //.Where()
                .Include(j => j.JobCategory)
                .Select(j => new JobViewModel
                {
                    Id = j.Id,
                    Name = j.Name,
                    CompanyName = j.CompanyName,
                    Location = j.Location,
                    Description = j.Description,
                    ImagePath = j.ImagePath,
                    JobCategory = j.JobCategory.Name,
                    Requirements = j.Requirements
                })
                .ToListAsync();
            if (isForHome)
            {
                return View("HomeViewJobList", items);
            }
            return View(items);
        }
        private Task<List<JobViewModel>> GetItemsAsync()
        {
            return _context!.Jobs!
                //.Where()
                .Select(j => new JobViewModel
                {
                    Id = j.Id,
                    Name = j.Name,
                    CompanyName = j.CompanyName,
                    Location = j.Location,
                    Description = j.Description,
                    ImagePath = j.ImagePath,
                    JobCategory = j.JobCategory.Name,
                    Requirements = j.Requirements
                })
                .ToListAsync();
        }
    }
}
