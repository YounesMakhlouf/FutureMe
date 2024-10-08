using FutureMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using FutureMe.Repositories;

namespace FutureMe.Controllers
{
    public class LettersController : Controller
    {
        private readonly ILetterRepository _letterRepository;
        private readonly ILogger<LettersController> _logger;

        public LettersController(ILetterRepository letterRepository, ILogger<LettersController> logger)
        {
            _letterRepository = letterRepository;
            _logger = logger;
        }

        // GET: Letters
        public async Task<IActionResult> Index()
        {
            try
            {
                var letters = await _letterRepository.GetPublicLettersAsync();
                return View(letters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving public letters.");
                return StatusCode(500, "An error occurred while retrieving letters.");
            }
        }

        // GET: Letters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Letter ID is required.");
            }

            try
            {
                var letter = await _letterRepository.GetLetterByIdAsync(id.Value);
                if (letter == null || !letter.IsPublic)
                {
                    return NotFound();
                }

                return View(letter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving letter with ID {LetterId}.", id);
                return StatusCode(500, "An error occurred while retrieving the letter.");
            }
        }
    }
}