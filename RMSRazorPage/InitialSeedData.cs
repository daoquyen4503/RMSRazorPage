using Microsoft.AspNetCore.Identity;
using RMSRazorPage.Data;

namespace RMSRazorPage
{
    public class InitialSeedData
    {
        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Manager", "Chef", "Cashier", "Waiter", "Customer" };

            // Tạo role nếu chưa có
            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Tạo user cho mỗi role (trừ Customer)
            await CreateUser(userManager, "manager@rms.com", "Manager123!", "Manager");
            await CreateUser(userManager, "chef@rms.com", "Chef123!", "Chef");
            await CreateUser(userManager, "cashier@rms.com", "Cashier123!", "Cashier");
            await CreateUser(userManager, "waiter@rms.com", "Waiter123!", "Waiter");
        }

        private static async Task CreateUser(UserManager<ApplicationUser> userManager, string email, string password, string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
