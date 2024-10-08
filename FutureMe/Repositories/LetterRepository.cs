using FutureMe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureMe.Repositories
{
    public class LetterRepository : ILetterRepository
    {
        private readonly AppDbContext _context;

        public LetterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Letter letter)
        {
            await _context.Letters.AddAsync(letter);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Letter>> GetTodaysLettersAsync()
        {
            var today = DateTime.UtcNow.Date;
            return await _context.Letters
                .Where(letter => letter.SendingDate.Date == today)
                .ToListAsync();
        }

        public async Task<List<Letter>> GetPublicLettersAsync()
        {
            return await _context.Letters
                .Where(letter => letter.IsPublic)
                .OrderByDescending(letter => letter.WritingDate)
                .ToListAsync();
        }
    }
}
