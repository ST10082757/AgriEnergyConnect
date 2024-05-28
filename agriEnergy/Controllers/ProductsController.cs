using Microsoft.AspNetCore.Mvc;
using agriEnergy.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using agriEnergy.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace agriEnergy.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductsDbContext _context;
        private readonly UserManager<agriEnergyUser> _userManager;

        public ProductsController(ProductsDbContext context, UserManager<agriEnergyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }


        public async Task<IActionResult> Index(string filterType, string searchValue)
        {
            var userId = GetUserId(); // Get the current user's ID
            var products = _context.ProductsDetails.Include(p => p.User)
                                                   .Where(p => p.userID == userId) // Filter by user ID
                                                   .AsQueryable();

            if (!string.IsNullOrEmpty(filterType) && !string.IsNullOrEmpty(searchValue))
            {
                if (filterType == "Date" && DateTime.TryParseExact(searchValue, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime filterDate))
                {
                    products = products.Where(p => p.date.Date == filterDate.Date);
                }
                else if (filterType == "Category")
                {
                    products = products.Where(p => p.category.Contains(searchValue));
                }
            }

            return View(await products.ToListAsync());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(createProduct model)
        {                
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the current user's ID
            ModelState.Remove("userID"); // Remove the userID from the model state to avoid validation errors

            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    productName = model.productName,
                    price = model.price,
                    category = model.category,
                    date = DateTime.Now,
                    userID = userId
                };

                _context.ProductsDetails.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }

            // If model state is not valid, return the same view with the model to show validation errors
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var userId = GetUserId(); // Get the current user's ID
            var product = _context.ProductsDetails.Find(id);

            if (product == null || product.userID != GetUserId())
            {
                return RedirectToAction(nameof(Index));
            }

            var editModel = new createProduct
            {
                Id = product.Id,
                productName = product.productName,
                price = product.price,
                category = product.category
            };

            return View(editModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(createProduct model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["id"] = model.Id;
                return View(model);
            }
            var userId = GetUserId(); // Get the current user's ID
            var product = await _context.ProductsDetails.FindAsync(model.Id);
            if (product == null || product.userID != userId)
            {
                return RedirectToAction(nameof(Index));
            }

            // Update the existing product with the new values
            product.productName = model.productName;
            product.price = model.price;
            product.category = model.category;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ProductsDetails.Any(e => e.Id == model.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var userId = GetUserId(); // Get the current user's ID
            var product = _context.ProductsDetails.Find(id);

            if (product == null || product.userID != userId)
            {
                return RedirectToAction("Index", "Products");
            }
            _context.ProductsDetails.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");

        }

    }
}
