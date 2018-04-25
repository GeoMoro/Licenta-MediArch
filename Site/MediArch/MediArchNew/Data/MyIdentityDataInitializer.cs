using System;
using Microsoft.AspNetCore.Identity;
using MediArch.Models;

namespace MediArch.Data
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
            //1 Owner
            if (userManager.FindByNameAsync("Owner@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Owner@gmail.com",
                    FirstName = "George-Cosmin",
                    LastName = "Morosanu",
                    BirthDate = new DateTime(1996, 09, 17),
                    Email = "Owner@gmail.com",
                    PhoneNumber = "0750000000"
                };

                IdentityResult result = userManager.CreateAsync(user, "Owner007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Owner").Wait();
                }
            }

            //3 Moderators
            if (userManager.FindByNameAsync("Moderator1@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Moderator1@gmail.com",
                    FirstName = "Ionut-Alexandru",
                    LastName = "Zaharia",
                    BirthDate = new DateTime(1996, 11, 25),
                    Email = "Moderator1@gmail.com",
                    PhoneNumber = "0750000001"
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
                    FirstName = "Alexandru",
                    LastName = "Corfu",
                    BirthDate = new DateTime(1996, 11, 15),
                    Email = "Moderator2@gmail.com",
                    PhoneNumber = "0750000002"
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
                    FirstName = "Robert-Ilie",
                    LastName = "Vicol",
                    BirthDate = new DateTime(1996, 07, 01),
                    Email = "Moderator3@gmail.com",
                    PhoneNumber = "0750000003"
                };

                IdentityResult result = userManager.CreateAsync(user, "Moderator007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Moderator").Wait();
                }
            }

            //5 Medics
            if (userManager.FindByNameAsync("Medic1@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Medic1@gmail.com",
                    FirstName = "Radu",
                    LastName = "Vulpescu",
                    BirthDate = new DateTime(1996, 12, 18),
                    Email = "Medic1@gmail.com",
                    PhoneNumber = "0751000000",
                    Title = "Medic Dentist",
                    CabinetAdress = "str. Decebal, Bl 374, Iasi"
                };

                IdentityResult result = userManager.CreateAsync(user, "Medic007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Medic").Wait();
                }
            }

            if (userManager.FindByNameAsync("Medic2@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Medic2@gmail.com",
                    FirstName = "Adrian",
                    LastName = "Dorneanu",
                    BirthDate = new DateTime(1996, 07, 23),
                    Email = "Medic2@gmail.com",
                    PhoneNumber = "0751000001",
                    Title = "Medic Dentist",
                    CabinetAdress = "str. Decebal, Bl 373, Iasi"
                };

                IdentityResult result = userManager.CreateAsync(user, "Medic007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Medic").Wait();
                }
            }

            if (userManager.FindByNameAsync("Medic3@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Medic3@gmail.com",
                    FirstName = "Razvan",
                    LastName = "Cimpoesu",
                    BirthDate = new DateTime(1996, 10, 29),
                    Email = "Medic3@gmail.com",
                    PhoneNumber = "0751000002",
                    Title = "Medic Dentist",
                    CabinetAdress = "str. Decebal, Bl 372, Vaslui"
                };

                IdentityResult result = userManager.CreateAsync(user, "Medic007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Medic").Wait();
                }
            }

            if (userManager.FindByNameAsync("Medic4@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Medic4@gmail.com",
                    FirstName = "Sergiu",
                    LastName = "Boistean",
                    BirthDate = new DateTime(1996, 06, 25),
                    Email = "Medic4@gmail.com",
                    PhoneNumber = "0751000003",
                    Title = "Medic Dentist",
                    CabinetAdress = "str. Decebal, Bl 371, Piatra Neamt"
                };

                IdentityResult result = userManager.CreateAsync(user, "Medic007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Medic").Wait();
                }
            }

            if (userManager.FindByNameAsync("Medic5@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Medic5@gmail.com",
                    FirstName = "Andreea-Bianca",
                    LastName = "Balan",
                    BirthDate = new DateTime(1996, 10, 29),
                    Email = "Medic5@gmail.com",
                    PhoneNumber = "0751000004",
                    Title = "Medic Dentist",
                    CabinetAdress = "str. Decebal, Bl 370, Vaslui"
                };

                IdentityResult result = userManager.CreateAsync(user, "Medic007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Medic").Wait();
                }
            }

            //10 Pacients
            if (userManager.FindByNameAsync("Pacient1@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient1@gmail.com",
                    FirstName = "George",
                    LastName = "Mazilu",
                    BirthDate = new DateTime(1996, 12, 19),
                    Email = "Pacient1@gmail.com",
                    PhoneNumber = "0752000000"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

            if (userManager.FindByNameAsync("Pacient2@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient2@gmail.com",
                    FirstName = "Simona",
                    LastName = "Stavarache",
                    BirthDate = new DateTime(1996, 06, 01),
                    Email = "Pacient2@gmail.com",
                    PhoneNumber = "0752000001"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

            if (userManager.FindByNameAsync("Pacient3@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient3@gmail.com",
                    FirstName = "Andreea",
                    LastName = "Giurgila",
                    BirthDate = new DateTime(1996, 02, 04),
                    Email = "Pacient3@gmail.com",
                    PhoneNumber = "0752000002"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

            if (userManager.FindByNameAsync("Pacient4@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient4@gmail.com",
                    FirstName = "Sergiu",
                    LastName = "Simoion",
                    BirthDate = new DateTime(1996, 01, 13),
                    Email = "Pacient4@gmail.com",
                    PhoneNumber = "0752000003"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

            if (userManager.FindByNameAsync("Pacient5@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient5@gmail.com",
                    FirstName = "Alex",
                    LastName = "Hagiu",
                    BirthDate = new DateTime(1996, 10, 27),
                    Email = "Pacient5@gmail.com",
                    PhoneNumber = "0752000004"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

            if (userManager.FindByNameAsync("Pacient6@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient6@gmail.com",
                    FirstName = "Vlad",
                    LastName = "Minuti",
                    BirthDate = new DateTime(1995, 12, 31),
                    Email = "Pacient6@gmail.com",
                    PhoneNumber = "0752000005"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

            if (userManager.FindByNameAsync("Pacient7@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient7@gmail.com",
                    FirstName = "Rares",
                    LastName = "Chelmus",
                    BirthDate = new DateTime(1996, 12, 30),
                    Email = "Pacient7@gmail.com",
                    PhoneNumber = "0752000006"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

            if (userManager.FindByNameAsync("Pacient8@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient8@gmail.com",
                    FirstName = "Anca",
                    LastName = "Ursachi",
                    BirthDate = new DateTime(1996, 04, 16),
                    Email = "Pacient8@gmail.com",
                    PhoneNumber = "0752000007"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

            if (userManager.FindByNameAsync("Pacient9@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient9@gmail.com",
                    FirstName = "Dragos",
                    LastName = "Larion",
                    BirthDate = new DateTime(1996, 10, 26),
                    Email = "Pacient9@gmail.com",
                    PhoneNumber = "0752000008"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

            if (userManager.FindByNameAsync("Pacient10@gmail.com").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Pacient10@gmail.com",
                    FirstName = "Andrei",
                    LastName = "Pintilie",
                    BirthDate = new DateTime(1996, 03, 19),
                    Email = "Pacient10@gmail.com",
                    PhoneNumber = "0752000009"
                };

                IdentityResult result = userManager.CreateAsync(user, "Pacient007!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Pacient").Wait();
                }
            }

        }
    }
}
