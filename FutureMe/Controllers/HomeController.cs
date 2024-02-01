using FutureMe.Models;
using FutureMe.Services.LetterSaver;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FutureMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILetterSaverService _letterSaverService;

        public HomeController(ILogger<HomeController> logger, ILetterSaverService letterSaverService)
        {
            _logger = logger;
            _letterSaverService = letterSaverService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveLetter([FromForm] Letter letter)
        {
            if (!ModelState.IsValid)
            {
                return (RedirectToAction(nameof(Index)));
            }
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                letter.UserId = Int32.Parse(userId);
            }

            _letterSaverService.saveLetter(letter);
            //TODO:Add success message to view
            TempData["Success"] = "Letter saved successfully !";
            return (RedirectToAction(nameof(Index)));


        }


    }
}
