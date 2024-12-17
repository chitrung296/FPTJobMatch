using FPTJobMatch.MVC.Commons;
using FPTJobMatch.MVC.Data;
using FPTJobMatch.MVC.Data.Entities;
using FPTJobMatch.MVC.Models;
using FPTJobMatch.MVC.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTJobMatch.MVC.Controllers
{
    public class JobCategoryController : Controller
    {
        private readonly AppDbContext _context;
        public JobCategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobCategoryViewModel jobCategoryVM)
        {
            var statusCode = new StatusCode
            {
                Message = "Chưa thực thi",
                Code = 0,
            };
            try
            {
                var validator = new JobCategoryValidator();
                var result = validator.Validate(jobCategoryVM);
                if (result.IsValid)
                {
                    var countJobCategory = await _context.JobCategories.CountAsync();
                    var newJobCategory = new JobCategory
                    {
                        Name = jobCategoryVM.Name.Trim(),
                        Description = jobCategoryVM.Description?.Trim(),
                        Position = ++countJobCategory
                    };
                    _context.JobCategories.Add(newJobCategory);
                    await _context.SaveChangesAsync();
                    statusCode.Code = 1;
                    statusCode.Message = "Tạo thành công";
                }
            }
            catch
            {
                statusCode.Code = -1;
                statusCode.Message = "Tạo thất bại";
            }
            
            return Json(statusCode);
        }
    }
}
