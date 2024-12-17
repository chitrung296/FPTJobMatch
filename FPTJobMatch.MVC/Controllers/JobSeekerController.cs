using FPTJobMatch.MVC.Data;
using FPTJobMatch.MVC.Data.Entities;
using FPTJobMatch.MVC.Helpers;
using FPTJobMatch.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTJobMatch.MVC.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly AppDbContext _context;
        public JobSeekerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Occupations = DataHelper.GetOccupationSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobSeekerViewModel jobSeeker)
        {
            try
            {
                var countJobSeeker = await _context.JobSeekers.CountAsync();
                var newJobSeeker = new JobSeeker
                {
                    Position = ++countJobSeeker,

                };

                newJobSeeker.GetNameFromFullname(jobSeeker.FullName);
                _context.JobSeekers.Add(newJobSeeker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
            }
            ViewBag.Occupations = DataHelper.GetOccupationSelectList();
            return View(jobSeeker);
        }

        public async Task<IActionResult> Edit(Guid idJobSeeker)
        {
            ViewBag.Occupations = DataHelper.GetOccupationSelectList();
            
            var jobSeekerVM = await _context.JobSeekers
                .Where(j => j.Id.Equals(idJobSeeker))
                .Select(j => new JobSeekerViewModel
                {
                    Id = j.Id,
                    FullName = j.FullName,
                    Name = j.Name,
                    Position = j.Position,
                    Phone = j.Phone,    
                    Email = j.Email,
                    Occupation = j.Occupation,
                    Gender = j.Gender,
                    DateOfBirth = j.DateOfBirth,
                })
                .SingleOrDefaultAsync();
           
            return View(nameof(Create), jobSeekerVM);
        }
        [HttpPost]
        
        public async Task<IActionResult> Edit(JobSeekerViewModel jobSeekerVM)
        {
            try
            {
                var jobSeeker = await _context.JobSeekers
                    .FindAsync(jobSeekerVM.Id);
                jobSeeker.FullName = jobSeekerVM.FullName;
                jobSeeker.GetNameFromFullname(jobSeekerVM.FullName);
                jobSeeker.DateOfBirth = jobSeekerVM.DateOfBirth;
                jobSeeker.Gender = jobSeekerVM.Gender;
                jobSeeker.Occupation = jobSeekerVM.Occupation;
                jobSeeker.Email = jobSeekerVM.Email;
                jobSeeker.Phone = jobSeekerVM.Phone;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
            }
            ViewBag.Occupations = DataHelper.GetOccupationSelectList();
            return View(nameof(Create), jobSeekerVM);
        }
    }
}
