using FutureMe.Models;
using FutureMe.Repositories;

namespace FutureMe.Services.LetterSaver
{
    public interface ILetterSaverService
    {
        public void saveLetter(Letter letter);
    }
}
