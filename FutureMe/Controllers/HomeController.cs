using FutureMe.Models;
using FutureMe.Services.LetterSaver;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

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
            return View(new Letter());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLetter([Bind("Title,Content,Email,SendingDate,IsPublic")] Letter letter)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", letter);
            }
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                letter.UserId = userId;
            }

            letter.WritingDate = DateTime.UtcNow;
            try
            {
                await _letterSaverService.SaveLetterAsync(letter);
                TempData["Success"] = "Letter saved successfully!";
                _logger.LogInformation("Letter saved successfully for Email: {Email}", letter.Email);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving letter for Email: {Email}", letter.Email);
                ModelState.AddModelError(string.Empty, "An error occurred while saving the letter. Please try again.");
                return View("Index", letter);
            }
        }
    }
}