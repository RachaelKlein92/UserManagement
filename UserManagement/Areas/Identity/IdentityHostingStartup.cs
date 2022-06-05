﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Areas.Identity.Data;
using UserManagement.Data;

[assembly: HostingStartup(typeof(UserManagement.Areas.Identity.IdentityHostingStartup))]
namespace UserManagement.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserManagementContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("UserManagementContextConnection"), new MySqlServerVersion(new Version())));

                services.AddDefaultIdentity<UserManagementUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<UserManagementContext>();
            });
        }
    }
}