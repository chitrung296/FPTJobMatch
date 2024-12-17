using FPTJobMatch.MVC.Data;
using FPTJobMatch.MVC.Data.Entities;
using FPTJobMatch.MVC.Helpers;
using FPTJobMatch.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTJobMatch.MVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;

        public CompanyController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyViewModel companyVM)
        {
            try
            {
                var countCompany = await _context.Companies.CountAsync();
                var newCompany = new Company
                {
                    Name = companyVM.Name,
                    Address = companyVM.Address,
                    Email = companyVM.Email,
                    Hotline = companyVM.Hotline,
                    TaxNumber = companyVM.TaxNumber,
                    Position = countCompany + 1,
                };
                _context.Companies.Add(newCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            catch
            {

            }
            
            return View(companyVM);
        }

        public async Task<IActionResult> Edit(Guid idCompany)
        {
            var companyVM = await _context.Companies
                .Where(c => c.Id.Equals(idCompany))
                .Select(c => new CompanyViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Position = c.Position,
                    Hotline = c.Hotline,
                    Email = c.Email,
                    TaxNumber= c.TaxNumber,
                    Address = c.Address,
                    
                })
                .SingleOrDefaultAsync();
            return View(nameof(Create), companyVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CompanyViewModel companyVM)
        {
            try
            {
                var company = await _context.Companies
                    .FindAsync(companyVM.Id);
                if (company != null)
                {
                    company.Name = companyVM.Name;
                    company.TaxNumber = companyVM.TaxNumber;
                    company.Address = companyVM.Address;
                    company.Email = companyVM.Email;
                    company.Hotline = companyVM.Hotline;

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
                }
            }
            catch
            {
            }
            return View(nameof(Create), companyVM);
        }
    }
}
