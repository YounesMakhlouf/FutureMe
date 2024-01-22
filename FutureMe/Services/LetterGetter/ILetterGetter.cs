using FutureMe.Models;

namespace FutureMe.Services.LetterGetter
{
    public interface ILetterGetter
    {
        public List<Letter> GetTodaysLetters();
    }
}
