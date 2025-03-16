using InfrastructureLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DbInitializer
{
    public  class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;
        }

        public void Initialize()
        {
            //Migration 
            try
            {

                if (_applicationDbContext.Database.GetPendingMigrations().Count() > 0)
                {
                    _applicationDbContext.Database.Migrate();
                }

            }
            catch (Exception ex)
            {
            }

            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
                

            }

            IdentityResult result = _userManager.CreateAsync(new IdentityUser
            {
                //UserName = "superadmin@inklusiv.com",
                //Email = "superadmin@inklusiv.com",
                
                //PhoneNumber = "01111111111"
                UserName = "quizeAdmin@quize.com",
                Email = "quizeAdmin@quize.com",
                PhoneNumber = "1234567890"

            }, "@password2000123M").GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                var user = _userManager.FindByEmailAsync("quizeAdmin@quize.com").GetAwaiter().GetResult();
                if (user != null)
                {
                    _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
                }
            }

            return;
        }


    }
}
