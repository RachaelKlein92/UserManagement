using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace UserManagement.Controllers
{
    public class UserListController : Controller
    {
        private readonly UserManager<UserManagementUser> _userManager;

        public UserListController(UserManager<UserManagementUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if(!HttpContext.User.IsInRole("Admin"))
            {
                return Redirect("/");
            }

            var roles = await _userManager.Users.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        public IActionResult AddUser()
        {
            return RedirectToAction("Index", "UserDetails");
        }

        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == default)
            {
                ModelState.AddModelError(string.Empty, $"Unable to find user with id {id}");
                return View("Index");
            }
            return RedirectToAction("Index", "UserDetails", user);
        }

        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == default)
            {
                ModelState.AddModelError(string.Empty, $"Unable to find user with id {id}");
            }

            await _userManager.SetLockoutEnabledAsync(user, true);
            var result = await _userManager.SetLockoutEndDateAsync(user, DateTime.Today.AddYears(1000));

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, $"Unable to delete user with id {id}");
            }

            return RedirectToAction("Index");
        }

    }
}
