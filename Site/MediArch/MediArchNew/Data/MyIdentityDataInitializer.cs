﻿using System;
using Microsoft.AspNetCore.Identity;

namespace MediArchNew.Data
{
    public static class MyIdentityDataInitializer
    {
        public static void SeedData(RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            roleManager.CreateRole("Owner");
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
    }
}
