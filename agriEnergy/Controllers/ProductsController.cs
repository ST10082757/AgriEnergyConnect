using Microsoft.AspNetCore.Mvc;
using agriEnergy.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using agriEnergy.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace agriEnergy.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductsDbContext _context;

        public ProductsController(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string filterType, string searchValue)
        {
            var products = from p in _context.ProductsDetails select p;

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
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    productName = model.productName,
                    price = model.price,
                    category = model.category,
                    date = DateTime.Now
                };

                _context.ProductsDetails.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            Product prod = new Product()
            {
                productName = model.productName,
                price = model.price,
                category = model.category,
                date = DateTime.Now

            }; 
            
            _context.ProductsDetails.Add(prod);
            _context.SaveChanges();

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var product = _context.ProductsDetails.Find(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var editModel = new createProduct
            {
                productName = product.productName,
                price = product.price,
                category = product.category
            };

            ViewData["id"] = id;
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

            var product = await _context.ProductsDetails.FindAsync(model.Id);
            if (product == null)
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
            var product = _context.ProductsDetails.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Products");
            }
            _context.ProductsDetails.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Products");

        }

    }
}
