using ChallengeApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChallengeApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public int Score { get; set; }
        public string Answer { get; set; }
        public List<string> CorrectAnswers { get; set; } = new List<string>();
        public ObservableCollection<string> GivenAnswers { get; set; } = new ObservableCollection<string>();
        private readonly IWordService wordService;

        public ICommand CheckAnswerCommand => new Command(async () => await CheckAnswerAsync());

        public MainViewModel(IWordService wordService)
        {
            this.wordService = wordService;
        }

        public override async void Init(object initData)
        {
            base.Init(initData);

            CorrectAnswers = await wordService.GetCorrectAnswers();
        }

        async Task CheckAnswerAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                if (!IsItemInTheList(Answer, GivenAnswers.ToList()) && IsItemInTheList(Answer, CorrectAnswers))
                {
                    GivenAnswers.Add(Answer);
                    Score = Score + 1;
                    Answer = string.Empty;
                }
            }
            catch (System.Exception ex)
            {
                await CoreMethods.DisplayAlert("", "Erro ao checar resposta", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        bool IsItemInTheList(string answer, List<string> answers)
        {
            if (answers == null || !answers.Any() || string.IsNullOrWhiteSpace(answer))
            {
                return false;
            }

            return answers.Any(c => c.ToLowerInvariant() == answer.ToLowerInvariant());
        }
    }
}
