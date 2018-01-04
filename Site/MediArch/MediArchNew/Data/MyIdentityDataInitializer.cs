using System;
using Microsoft.AspNetCore.Identity;
using MediArchNew.Models;

namespace MediArchNew.Data
{
    public static class MyIdentityDataInitializer
    {
        public static void SeedData(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            roleManager.CreateRole("Owner");
            roleManager.CreateRole("Moderator");
            roleManager.CreateRole("Medic");
            roleManager.CreateRole("Pacient");
        }

        public static void CreateRole(this RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (roleManager.RoleExistsAsync(roleName).Result)
            {
                return;
            }

            var role = new IdentityRole
            {
                Name = roleName
            };

            var roleResult = roleManager.CreateAsync(role).Result;

            if (!roleResult.Succeeded)
            {
                throw new Exception("Error creating role");
            }
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("Owner@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Owner@gmail.com",
                    CNP = 1960917374518,
                    FirstName = "George-Cosmin",
                    LastName = "Morosanu",
                    BirthDate = new DateTime(1996, 10, 11),
                    Email = "Owner@gmail.com",
                    PhoneNumber = "075222222"
                };

                IdentityResult result = userManager.CreateAsync(user, "Owner007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Owner").Wait();
                }
            }

            if (userManager.FindByNameAsync("Moderator1@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Moderator1@gmail.com",
                    CNP = 1960917374001,
                    FirstName = "Ionut",
                    LastName = "Zaharia",
                    BirthDate = new DateTime(1996, 11, 12),
                    Email = "Moderator1@gmail.com",
                    PhoneNumber = "0751222222"
                };

                IdentityResult result = userManager.CreateAsync(user, "Moderator007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Moderator").Wait();
                }
            }

            if (userManager.FindByNameAsync("Moderator2@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Moderator2@gmail.com",
                    CNP = 1960917374002,
                    FirstName = "Alexandru",
                    LastName = "Corfu",
                    BirthDate = new DateTime(1996, 11, 12),
                    Email = "Moderator2@gmail.com",
                    PhoneNumber = "0751222222"
                };

                IdentityResult result = userManager.CreateAsync(user, "Moderator007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Moderator").Wait();
                }
            }

            if (userManager.FindByNameAsync("Moderator3@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Moderator3@gmail.com",
                    CNP = 1960917374003,
                    FirstName = "Adrian",
                    LastName = "Dorneanu",
                    BirthDate = new DateTime(1996, 11, 12),
                    Email = "Moderator3@gmail.com",
                    PhoneNumber = "0751222222"
                };

                IdentityResult result = userManager.CreateAsync(user, "Moderator007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Moderator").Wait();
                }
            }

            if (userManager.FindByNameAsync("Pacient1@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient1@gmail.com",
                    CNP = 1960917374003,
                    FirstName = "George",
                    LastName = "Mazilu",
                    BirthDate = new DateTime(1996, 11, 12),
                    Email = "Pacient1@gmail.com",
                    PhoneNumber = "0751333333"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

            if (userManager.FindByNameAsync("Medic1@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Medic1@gmail.com",
                    CNP = 1960917374003,
                    FirstName = "Radu",
                    LastName = "Vulpescu",
                    BirthDate = new DateTime(1996, 11, 12),
                    Email = "Medic1@gmail.com",
                    PhoneNumber = "0751444444",
                    Title = "Medic Dentist",
                    CabinetAdress = "str. Decebal, Bl 374, Iasi"
                };

                IdentityResult result = userManager.CreateAsync(user, "Medic007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Medic").Wait();
                }
            }
        }
    }
}
