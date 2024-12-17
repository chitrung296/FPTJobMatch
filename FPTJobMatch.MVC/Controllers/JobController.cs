using FPTJobMatch.MVC.Commons;
using FPTJobMatch.MVC.Data;
using FPTJobMatch.MVC.Data.Entities;
using FPTJobMatch.MVC.Models;
using FPTJobMatch.MVC.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FPTJobMatch.MVC.Controllers
{
    public class JobController : Controller
    {
        private readonly AppDbContext _context;
        public JobController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.JobCategories = await GetJobCategorySelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobViewModel jobVM)
        {
            var validator = new JobValidator();
            try
            {
                var result = await validator.ValidateAsync(jobVM);
                if (result.IsValid)
                {
                    var countJob = await _context.Jobs.CountAsync();
                    var newJob = new Job
                    {
                        Name = jobVM.Name.Trim(),
                        Description = jobVM.Description.Trim(),
                        Requirements = jobVM.Requirements?.Trim(),
                        JobCategoryId = jobVM.JobCategoryId,
                        ImagePath = jobVM.ImagePath,
                        CompanyName = jobVM.CompanyName,
                        Location = jobVM.Location,
                        Position = countJob + 1,
                    };
                    _context.Jobs.Add(newJob);
                    await _context.SaveChangesAsync();
                    //ViewBag.Announcement = "Tạo thành công";
                    ViewData[ViewBags.ANNOUNCEMENT] = "Tạo thành công";
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                ViewBag.JobCategories = await GetJobCategorySelectList();

                //ViewBag.Announcement = "Tạo thất bại";
                ViewData[ViewBags.ANNOUNCEMENT] = "Tạo thất bại";
            }

            return View(jobVM);
        }

        public async Task<IActionResult> Edit(Guid idJob)
        {
            var jobVM = await _context.Jobs
                .Where(j => j.Id.Equals(idJob))
                .Select(j => new JobViewModel
                {
                    Id = j.Id,
                    Name = j.Name,
                    Description = j.Description,
                    Requirements = j.Requirements,
                    JobCategoryId = j.JobCategoryId,
                })
                .SingleOrDefaultAsync();

            ViewBag.JobCategories = await GetJobCategorySelectList();

            return View(nameof(Create), jobVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobViewModel jobVM)
        {
            var validator = new JobValidator();
            try
            {
                var result = await validator.ValidateAsync(jobVM);
                if (result.IsValid)
                {
                    var job = await _context.Jobs
                        .Where(j => j.Id.Equals(jobVM.Id))
                        .SingleOrDefaultAsync();

                    if (job != null)
                    {
                        job.Name = jobVM.Name.Trim();
                        job.Description = jobVM.Description.Trim();
                        job.Requirements = jobVM.Requirements?.Trim();
                        job.JobCategoryId = jobVM.JobCategoryId;

                        await _context.SaveChangesAsync();
                        //ViewBag.Announcement = "Tạo thành công";
                        ViewData[ViewBags.ANNOUNCEMENT] = "Tạo thành công";
                        return RedirectToAction("Create");
                    }
                }
            }
            catch
            {
                ViewBag.JobCategories = await GetJobCategorySelectList();

                //ViewBag.Announcement = "Tạo thất bại";
                ViewData[ViewBags.ANNOUNCEMENT] = "Tạo thất bại";
            }

            return View(nameof(Create), jobVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid idJob)
        {
            var statusCode = false;
            var message = "Chưa thực thi";
            try
            {
                var job = await _context.Jobs
                        .Where(j => j.Id.Equals(idJob))
                        .SingleOrDefaultAsync();

                if (job != null)
                {
                    _context.Jobs.Remove(job);

                    await _context.SaveChangesAsync();
                    statusCode = true;
                    message = "Xóa thành công";
                }
            }
            catch
            {
                message = "Lỗi thực thi";
            }

            return Json(new { message, statusCode });
        }

        public IActionResult GetAll()
        {
            return ViewComponent("JobList");
        }

        private async Task<SelectList> GetJobCategorySelectList()
        {
            var listJob = await _context.JobCategories
                .OrderBy(jt => jt.Position)
                .Select(jt => new Item
                {
                    Id = jt.Id,
                    Name = jt.Name,
                })
                .ToListAsync();
            listJob.Insert(0, new Item
            {
                Id = Guid.Empty,
                Name = "=== Chọn Job Category ==="
            });
            var selectList = new SelectList(listJob, "Id", "Name");
            return selectList;
        }
    }
}
