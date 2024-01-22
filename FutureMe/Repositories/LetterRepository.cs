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
        public void Add(string content,DateTime sendingDate, bool IsPublic, string Email, string Title, int UserId)
        {
            Letter letter = new Letter()
            {
                Content = content,
                WritingDate = new DateTime(),
                SendingDate = sendingDate,
                IsPublic = IsPublic,
                Email = Email,
                Title = Title,
                UserId = UserId,

            };
            _context.letters.Add(letter);
            _context.SaveChanges();
        }
    }
}
