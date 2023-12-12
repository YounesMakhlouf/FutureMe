using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FutureMe.Models;

namespace FutureMe.Controllers
{
    public class LettersController : Controller
    {
        private readonly AppDbContext _context;

        public LettersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Letters
        public async Task<IActionResult> Index()
        {
              return _context.Letters != null ? 
                          View(await _context.Letters.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Letters'  is null.");
        }

        // GET: Letters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Letters == null)
            {
                return NotFound();
            }

            var letter = await _context.Letters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // GET: Letters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Letters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,WritingDate,SendingDate,IsPublic,Email,Title")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(letter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(letter);
        }
    }
}
