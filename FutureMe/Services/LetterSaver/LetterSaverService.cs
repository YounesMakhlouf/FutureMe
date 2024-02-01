using FutureMe.Models;
using FutureMe.Repositories;

namespace FutureMe.Services.LetterSaver
{
    public class LetterSaverService : ILetterSaverService
    {
        private readonly LetterRepository _letterRepository;
        public LetterSaverService(LetterRepository letterRepository)
        {
            _letterRepository = letterRepository;
        }
        public void saveLetter(Letter letter)
        {
            _letterRepository.Add(letter);
        }
    }
}
