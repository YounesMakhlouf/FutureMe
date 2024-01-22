using FutureMe.Models;
using Quartz.Impl.AdoJobStore.Common;

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

        public List<Letter> GetTodaysLetters()
        {

                return _context.letters
                .Where(letter => letter.SendingDate.Date == DateTime.Today)
                .ToList();

            

        }

    }
}
