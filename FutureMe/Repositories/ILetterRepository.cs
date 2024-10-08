using FutureMe.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FutureMe.Repositories
{
    public interface ILetterRepository
    {
        Task AddAsync(Letter letter);
        Task<List<Letter>> GetUnsentLettersAsync();
        Task<List<Letter>> GetPublicLettersAsync();
        Task<Letter> GetLetterByIdAsync(int id);
        Task UpdateAsync(Letter letter);
    }
}