using FutureMe.Models;
using FutureMe.Repositories;

namespace FutureMe.Services.LetterSaver
{
    public class LetterSaverService : ILetterSaverService
    {
        private readonly ILetterRepository _letterRepository;

        public LetterSaverService(ILetterRepository letterRepository)
        {
            _letterRepository = letterRepository;
        }

        public async Task SaveLetterAsync(Letter letter)
        {
            await _letterRepository.AddAsync(letter);
        }
    }
}