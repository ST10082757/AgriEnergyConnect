using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using agriEnergy.Areas.Identity.Data;
using System.Threading.Tasks;
using agriEnergy.Models;

namespace agriEnergy
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("AuthorisationContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthorisationContextConnection' not found."); ;

            builder.Services.AddDbContext<AuthorisationContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<agriEnergyUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthorisationContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ProductsDbContext>(options =>
                           {
                               var connectionstring = builder.Configuration.GetConnectionString("AuthorisationContextConnection");
                               options.UseSqlServer(connectionstring);
                           });

            builder.Services.AddDbContext<FarmerDbContext>(options =>
            {
                var connectionstring = builder.Configuration.GetConnectionString("AuthorisationContextConnection");
                options.UseSqlServer(connectionstring);
            });

            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            // Ensure roles are created at startup
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Employee", "Farmer" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager =
                    scope.ServiceProvider.GetRequiredService<UserManager<agriEnergyUser>>();

                string email = "user@employee.com";
                string password = "Test123!";
                string firstName = "John"; // Add the first name

                // Check if the email ends with "employee.com"
                if (email.EndsWith("employee.com") && await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new agriEnergyUser();

                    user.UserName = email;
                    user.Email = email;
                    user.firstName = firstName;

                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Employee");
                }
            }
            app.Run();
        }
    }
}
