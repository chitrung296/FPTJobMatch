using FPTJobMatch.MVC.Data;
using FPTJobMatch.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTJobMatch.MVC.ViewComponents
{
    public class JobCategoryListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public JobCategoryListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context!.JobCategories!
                .Select(j => new JobCategoryViewModel
                {
                    Id = j.Id,
                    Name = j.Name,
                    Position = j.Position,
                    Description = j.Description,
                })
                .ToListAsync();
            return View(items);
        }
    }
}
