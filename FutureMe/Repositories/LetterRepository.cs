using FutureMe.Models;

namespace FutureMe.Repositories
{
    public class LetterRepository
    {
        private readonly AppDbContext _context;
        public LetterRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Letter letter)
        {
            _context.Letters.Add(letter);
            _context.SaveChanges();
        }

        public List<Letter> GetTodaysLetters()
        {
            return _context.Letters
            .Where(letter => letter.SendingDate.Date == DateTime.Today)
            .ToList();
        }
    }
}
