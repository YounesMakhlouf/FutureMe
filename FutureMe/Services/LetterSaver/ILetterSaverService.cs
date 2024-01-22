using FutureMe.Repositories;

namespace FutureMe.Services.LetterSaver
{
    public interface ILetterSaverService
    {
        public void saveLetter(string content, DateTime sendingDate, bool IsPublic, string Email, string Title, int UserId);
    }
}
