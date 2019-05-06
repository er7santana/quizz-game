using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ChallengeApp.Services
{
    public interface IWordService
    {
        Task<List<string>> GetCorrectAnswers();
    }
}
