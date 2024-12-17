using FPTJobMatch.MVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace FPTJobMatch.MVC.ViewComponents
{
    public class UserListViewComponent(AppDbContext context) : ViewComponent
    {
        private readonly AppDbContext _context = context;

        public IViewComponentResult Invoke()
        {
            var users = _context.Users
                .OrderBy(u => u.Position)
                .ToList();
            return View(users);
        }
    }
}
