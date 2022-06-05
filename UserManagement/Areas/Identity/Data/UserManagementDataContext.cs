using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.Areas.Identity.Data;

namespace UserManagement.Areas.Identity.Data
{
    public class UserManagementDataContext : IdentityDbContext<UserManagementUser>
    {
        public DbSet<AuditLog> AuditLogs { get; set; }

        public UserManagementDataContext(DbContextOptions<UserManagementDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<AuditLog>().HasKey(x => x.Id);

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Name = Enums.Roles.Admin.ToString(),
                    NormalizedName = Enums.Roles.Admin.ToString().ToUpper()
                });
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Name = Enums.Roles.User.ToString(),
                    NormalizedName = Enums.Roles.User.ToString().ToUpper()
                });
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Name = Enums.Roles.Reporter.ToString(),
                    NormalizedName = Enums.Roles.Reporter.ToString().ToUpper()
                });
        }
    }
}
