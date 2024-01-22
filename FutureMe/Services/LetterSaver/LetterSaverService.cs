using FutureMe.Repositories;

namespace FutureMe.Services.LetterSaver
{
    public class LetterSaverService:ILetterSaverService
    {
        private readonly LetterRepository _letterRepository;
        public LetterSaverService(LetterRepository letterRepository)
        {
            _letterRepository = letterRepository;
        }
        public void saveLetter(string content, DateTime sendingDate, bool IsPublic, string Email, string Title, int UserId)
        {
            _letterRepository.Add(content, sendingDate, IsPublic, Email, Title, UserId);
        }
    }
}
