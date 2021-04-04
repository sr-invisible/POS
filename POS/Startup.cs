using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using POS.Models;

[assembly: OwinStartupAttribute(typeof(POS.Startup))]
namespace POS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AddUsersAndRoles();
        }
        private async void AddUsersAndRoles()
        {
            // Deal wtih user
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ApplicationUser user = await UserManager.FindByEmailAsync("SuperAdmin@gmail.com");

            // Deal wtih user role
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());


            if (!rolemanager.RoleExists("Super Admin") && user != null)
            {
                //Create Default Role
                var role = new IdentityRole("Super Admin");
                rolemanager.Create(role);
                // Assigning Default Role
                UserManager.AddToRole(user.Id, "Super Admin");

                //Create Default Users
                //var user = new ApplicationUser
                //{
                //    UserName = "SuperAdmin@gmail.com",
                //    Email = "SuperAdmin@gmail.com",
                //    EmailConfirmed = true,
                //    FirstName = "Supper",
                //    LastName = "Admin",
                //    IsActive = true,
                //    DateCreated = DateTime.Now,
                //    DateUpdated = DateTime.Now
                //};
                //var result = await UserManager.CreateAsync(user, "SuperAdmin!23456");
                //if (result.Succeeded)
                //{
                //    UserManager.AddToRole(user.Id, "SuperAdmin");
                //}
            }

            if (!rolemanager.RoleExists("User") && user != null)
            {
                //Create Default Role
                var role = new IdentityRole("User");
                rolemanager.Create(role);
            }
        }
    }
}
