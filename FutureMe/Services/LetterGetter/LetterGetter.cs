using FutureMe.Models;
using FutureMe.Repositories;

namespace FutureMe.Services.LetterGetter
{
    public class LetterGetter : ILetterGetter
    {
        private readonly ILetterRepository _repository;

        public LetterGetter(ILetterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Letter>> GetUnsentLettersAsync()
        {
            return await _repository.GetUnsentLettersAsync();
        }
    }
}