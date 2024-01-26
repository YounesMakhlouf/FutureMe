using FutureMe.Models;
using FutureMe.Repositories;

namespace FutureMe.Services.LetterGetter
{
    public class LetterGetter : ILetterGetter
    {
        private readonly LetterRepository _repository;

        public LetterGetter(LetterRepository repository)
        {
            _repository = repository;
        }
        public List<Letter> GetTodaysLetters()
        {
            return _repository.GetTodaysLetters(); ;
            

            }

        }

    }

