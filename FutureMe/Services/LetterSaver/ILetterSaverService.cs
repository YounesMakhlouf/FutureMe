using FutureMe.Models;

namespace FutureMe.Services.LetterSaver
{
    public interface ILetterSaverService
    {
        Task SaveLetterAsync(Letter letter);
    }
}