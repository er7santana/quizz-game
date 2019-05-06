using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeApp.Services
{
    public class WordService : IWordService
    {
        private List<string> _mockList = new List<string>
        {
            "opala",
            "celta",
            "kadett",
            "corsa",
            "omega",
        };

        public async Task<List<string>> GetCorrectAnswers()
        {
            return await Task.FromResult(_mockList);
        }
    }
}
