using agriEnergy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace agriEnergy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
 //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Display the home page.
        /// </summary>
        /// <returns>Index view</returns>
        public IActionResult Index()
        {
            return View();
        }


        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Display the error page.
        /// </summary>
        /// <returns>Error view with an ErrorViewModel containing the request ID</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
//---------------------------------------- END OF FILE -------------------------------------------------------//

