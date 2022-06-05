using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using UserManagement.Areas.Identity.Data;

namespace UserManagement.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<UserManagementUser> _userManager;
        private readonly UserManagementDataContext _userManagementContext;

        public ConfirmEmailModel(UserManager<UserManagementUser> userManager,
            UserManagementDataContext userManagementContext)
        {
            _userManager = userManager;
            _userManagementContext = userManagementContext;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";


            // Create Registration Audit Log
            await _userManagementContext.AuditLogs.AddAsync(new AuditLog
            {
                DateTime = DateTime.UtcNow,
                EmailAddress = user.Email,
                Description = $"Registered: {user.FirstName} {user.LastName} successfully."
            });

            await _userManagementContext.SaveChangesAsync();

            if(_userManagementContext.Users.Count() == 1)
            {
                await _userManager.AddToRoleAsync(user, Enums.Roles.Admin.ToString());
            }

            if (_userManagementContext.Users.Count() == 2)
            {
                await _userManager.AddToRoleAsync(user, Enums.Roles.Reporter.ToString());
            }

            if(_userManagementContext.Users.Count() >= 3)
            {
                await _userManager.AddToRoleAsync(user, Enums.Roles.User.ToString());
            }

            return Page();
        }
    }
}
