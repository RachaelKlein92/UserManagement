using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace UserManagement.Controllers
{
    public class UserDetailsController : Controller
    {
        private readonly UserManager<UserManagementUser> _userManager;

        public UserDetailsController(UserManager<UserManagementUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index(UserManagementUser userManagementUser)
        {
            if (!HttpContext.User.IsInRole("Admin"))
            {
                return Redirect("/");
            }

            return View(userManagementUser);
        }

        // GET: UserList/Create
        [HttpPost]
        public async Task<ActionResult> SaveAsync(UserManagementUser userManagementUser)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Unable to save user, please ensure all required data is provided.");
                return View();
            }

            var existingUser = await _userManager.FindByIdAsync(userManagementUser.Id);

            if (existingUser == default)
            {
                userManagementUser.UserName = userManagementUser.Email;
                var result = await _userManager.CreateAsync(userManagementUser);

                if(!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, result.Errors.ToString());
                    return View();
                }
            }
            else
            {
                existingUser.FirstName = userManagementUser.FirstName;
                existingUser.LastName = userManagementUser.LastName;
                existingUser.Email = userManagementUser.Email;
                existingUser.Age = userManagementUser.Age;
                existingUser.Hobbies = userManagementUser.Hobbies;
                existingUser.PhoneNumber = userManagementUser.PhoneNumber;

                await _userManager.UpdateAsync(existingUser);
            }

            return RedirectToAction("Index", "UserList");
        }
    }
}
