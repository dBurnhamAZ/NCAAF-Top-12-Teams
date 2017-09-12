using NCAAFRepository.CSV;
using NCAAFRepository.GetLatestRankings;
using NCAAFRepository.Service;
using NCAAFTeamViewer.Presentation;
using System.Windows;

namespace TeamView.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ComposeObjects();
            Application.Current.MainWindow.Title = "Loose Coupling - Team Viewer";
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// App.xaml.cs will control the OnStart injection.
        /// In this example, all we have to do is unComment the Repository class
        /// for any desired start-up.
        /// This example has options of running a Service (WCF), a CSV file, or
        /// updated values directly from a NCAA Standings Webpage. 
        /// The purpose of this app is to demo decoupling and Depenency Injection
        /// By seperating each layer, we can use Interfaces for communications
        /// and Unit Testing
        /// </summary>
        private void ComposeObjects()
        {
            var repository = new PullLatestRankingsFromWebRepository();            
            //var repository = new CSVRepository();
           // var repository = new ServiceRepository();

            var viewModel = new TeamViewViewModel(repository);

            if (repository.GetType().Name == "CSVRepository")
            {
                viewModel.Repository = "CSVRepository";
            }
            else if(repository.GetType().Name == "ServiceRepository")
            {
                viewModel.Repository = "ServiceRepository";
            }
            else if(repository.GetType().Name == "PullLatestRankingsFromWebRepository")
            {
                viewModel.Repository = "WebsiteRepository";
            }
            
            Application.Current.MainWindow = new TeamViewWindow(viewModel);
        }
    }
}
