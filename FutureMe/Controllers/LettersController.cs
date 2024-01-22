﻿using FutureMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return _context.letters != null ?
                        View(await _context.letters.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Letters'  is null.");
        }

        // GET: Letters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.letters == null)
            {
                return NotFound();
            }

            var letter = await _context.letters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }
    }
}
