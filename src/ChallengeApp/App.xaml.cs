using ChallengeApp.Services;
using ChallengeApp.ViewModels;
using FreshMvvm;
using Xamarin.Forms;

namespace ChallengeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeIoC();
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
            var mainPage = FreshPageModelResolver.ResolvePageModel<MainViewModel>();
            var mainStack = new FreshNavigationContainer(mainPage, "mainStack");

            MainPage = mainStack;
        }

        private void InitializeIoC()
        {
            FreshMvvm.FreshIOC.Container.Register<IWordService, WordService>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
