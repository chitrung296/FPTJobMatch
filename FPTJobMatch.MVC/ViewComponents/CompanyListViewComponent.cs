using FPTJobMatch.MVC.Data;
using FPTJobMatch.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTJobMatch.MVC.ViewComponents
{
    public class CompanyListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public CompanyListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var companies = await _context.Companies
                .OrderBy(c => c.Position)
                .Select(c => new CompanyViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Position = c.Position,
                    Hotline = c.Hotline,
                    Email = c.Email,
                    Address = c.Address,
                    TaxNumber = c.TaxNumber,
                    
                })
                .ToListAsync();
            return View(companies);
        }
    }
}
