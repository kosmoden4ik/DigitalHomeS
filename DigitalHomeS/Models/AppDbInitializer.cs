using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalHomeS.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var roleAdmin = new IdentityRole { Name = "admin" };
            var roleUser = new IdentityRole { Name = "user" };

            roleManager.Create(roleAdmin);
            roleManager.Create(roleUser);

            var admin = new ApplicationUser { Email = "den4ik@gmail.com", UserName = "Denis" };
            string passwordAdmin = "24081991_Ua";
            var resultAdmin = userManager.Create(admin, passwordAdmin);
            if (resultAdmin.Succeeded)
            {
                userManager.AddToRole(admin.Id, roleAdmin.Name);
            }

            var user = new ApplicationUser { Email = "aninterio@gmail.com", UserName = "Nastya" };
            string passwordUser = "24081991_Ua";
            var resultUser = userManager.Create(user, passwordUser);
            if (resultUser.Succeeded)
            {
                userManager.AddToRole(user.Id, roleUser.Name);
            }

            base.Seed(context);
        }
    }
}