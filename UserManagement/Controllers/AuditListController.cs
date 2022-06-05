using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UserManagement.Controllers
{
    public class AuditListController : Controller
    {
        private readonly UserManagementDataContext _userManagementDataContext;

        public AuditListController(UserManagementDataContext userManagementDataContext)
        {
            _userManagementDataContext = userManagementDataContext;
        }
        public async Task<IActionResult> Index()
        {
            if (!HttpContext.User.IsInRole("Admin") && !HttpContext.User.IsInRole("Reporter"))
            {
                return Redirect("/");
            }

            var roles = await _userManagementDataContext
                .AuditLogs
                .OrderByDescending(x => x.DateTime)
                .ToListAsync();

            return View(roles);
        }

        [HttpPost]
        public IActionResult Back()
        {
            return RedirectToAction("Index", "UserList");
        }
    }
}
