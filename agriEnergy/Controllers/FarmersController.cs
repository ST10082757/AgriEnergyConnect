using agriEnergy.Areas.Identity.Data;
using agriEnergy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace agriEnergy.Controllers
{
    public class FarmersController : Controller
    {
        private readonly FarmerDbContext _context;
        public FarmersController(FarmerDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var farmers = _context.Farmers.OrderByDescending(p => p.Id).ToList();
            return View(farmers);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(addFarmers addfarmers)
        {
            if (ModelState.IsValid)
            {
                // Create a new Farmer entity and assign values from the addFarmers model
                var farmer = new Farmers
                {
                    name = addfarmers.name,
                    email = addfarmers.email,
                    password = addfarmers.password,
                    role = addfarmers.role // Assign role from the form
                };

                // Add the farmer to the context and save changes
                _context.Farmers.Add(farmer);
                _context.SaveChanges();

                // Redirect to the Farmers index action
                return RedirectToAction("Index", "Farmers");
            }
            // If ModelState is not valid, return to the create view with errors
            return View(addfarmers);
        }

        // Helper method to hash the password
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public IActionResult Edit(int id)
        {
            var farmer = _context.Farmers.Find(id);

            if (farmer == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var editModel = new addFarmers
            {
                name = farmer.name,
                email = farmer.email,
                role = farmer.role,
                password = farmer.password
            };

            ViewData["id"] = id;

            return View(editModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, addFarmers addfarmers)
        {

            var farmer = _context.Farmers.Find(id);

            if (farmer == null)
            {
                return RedirectToAction("Index", "Products");
            }

            farmer.name = addfarmers.name;
            farmer.email = addfarmers.email;
            farmer.role = addfarmers.role;
            farmer.password = addfarmers.password;

            _context.SaveChanges();

            return RedirectToAction("Index", "Farmers");

        }

        public IActionResult Delete(int id)
        {
            var farmer = _context.Farmers.Find(id);

            if (farmer == null)
            {
                return RedirectToAction("Index", "Products");
            }
            _context.Farmers.Remove(farmer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");

        }

    }
}
