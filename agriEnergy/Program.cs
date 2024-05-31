using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using agriEnergy.Areas.Identity.Data;
using System.Threading.Tasks;
using agriEnergy.Models;
using Microsoft.Extensions.DependencyInjection;

namespace agriEnergy
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("AuthorisationContextConnection")
                                   ?? throw new InvalidOperationException("Connection string 'AuthorisationContextConnection' not found.");

            builder.Services.AddDbContext<AuthorisationContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<agriEnergyUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthorisationContext>();

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
        

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Configure authorization policy
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("EmployeeOnly", policy => policy.RequireRole("Employee"));
            });

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

//--------------------------------------------------------------------------------------------------------//

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
//--------------------------------------------------------------------------------------------------------//

            // Ensure default user is created at startup
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<agriEnergyUser>>();

                string email = "user@employee.com";
                string password = "Test123!";
                string firstName = "John"; // Add the first name

                // Check if the email ends with "employee.com"
                if (email.EndsWith("employee.com") && await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new agriEnergyUser
                    {
                        UserName = email,
                        Email = email,
                        firstName = firstName
                    };

                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Employee");
                        // Add any additional roles needed
                    }
                }
            }
            app.Run();
        }
    }
}
        //---------------------------------------- END OF FILE -------------------------------------------------------//
