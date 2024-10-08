using FutureMe.Models;

namespace FutureMe.Services.LetterGetter
{
    public interface ILetterGetter
    {
        Task<List<Letter>> GetTodaysLettersAsync();
    }
}