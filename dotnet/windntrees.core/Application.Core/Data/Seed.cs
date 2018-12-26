using Application.Core.Models;
using Application.Core.Models.Configuration;
using DataAccess.Core;
using DataAccess.Core.Models;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core.Data
{
    public class Seed
    {
        private UserManager<ApplicationUser> ManagerUser { get; set; }        
        private IOptions<ApplicationSettings> OptionSettings { get; set; }
        private ILogger<Seed> _logger;

        public Seed(UserManager<ApplicationUser> userManager,
            IOptions<ApplicationSettings> options,
            ILogger<Seed> logger = null)
        {
            ManagerUser = userManager;
            OptionSettings = options;

            _logger = logger;
        }

        public async void Fill()
        {
            var existingUser = ManagerUser.FindByNameAsync(OptionSettings.Value.AdminEmail).Result;

            if (existingUser == null)
            {
                var RepositoryRoles = new IdentityRoleRepository(new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>()));

                //Setup Roles
                foreach (var role in OptionSettings.Value.AdminRoles)
                {
                    RepositoryRoles.Create(new IdentityRole
                    {
                        Id = role,
                        Name = role,
                        NormalizedName = role.ToUpper()
                    });

                    _logger.LogInformation(string.Format("{0} created.", role));
                }

                //Setup Administration User
                var user = new ApplicationUser
                {
                    UserName = OptionSettings.Value.AdminEmail,
                    Email = OptionSettings.Value.AdminEmail,
                    FirstName = OptionSettings.Value.AdminName,
                    LastName = "",
                    Title = "",
                    Sex = "",
                    CreationDate = DateTime.Now,
                    EmailConfirmed = true,
                    IsApproved = true,
                    ApprovedBy = "setup-registration"
                };

                var result = ManagerUser.CreateAsync(user).Result;
                if (result.Succeeded)
                {
                    //Add admin roles to the user.
                    var RepositoryUserRoles = new IdentityUserRoleRepository(new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()));
                    RepositoryUserRoles.AddUserRoles(user.Id, OptionSettings.Value.AdminRoles);

                    _logger.LogInformation(string.Format("{0} created a new account with {1}.", OptionSettings.Value.AdminEmail, OptionSettings.Value.AdminPassword));

                    //var code = _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //string callbackUrl = string.Format("Please confirm your account by clicking this link: <a href='http://localhost:50454/Account/ConfirmEmail?userId={0}&amp;code={1}'>link</a>", user.Id, code);
                    //_emailSender.SendEmailConfirmationAsync(applicationSettings.AdminEmail, callbackUrl);

                    try
                    {
                        ActivityHistoryRepository attendanceRepository = new ActivityHistoryRepository(new ApplicationContext());
                        attendanceRepository.Create(new ActivityHistory
                        {
                            Uid = Guid.NewGuid(),
                            ActivityTime = DateTime.UtcNow,
                            Activity = "new registration",
                            Request = "setup-registration",
                            UserId = user.Id,
                            Ipaddress = "setup-registration"
                        });
                    }
                    catch { }
                }
            }
        }
    }
}
