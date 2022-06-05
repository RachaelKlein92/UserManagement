using System.Collections.Generic;
using UserManagement.Areas.Identity.Data;

namespace UserManagement.Models
{
    public class UserManagementInput
    {
        public List<UserManagementUser> Users { get; set; }
    }
}
