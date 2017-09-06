using NCAAFRepository.CSV;
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

        private void ComposeObjects()
        {
            var repository = new CSVRepository();
            var viewModel = new TeamViewViewModel(repository);
            Application.Current.MainWindow = new TeamViewWindow(viewModel);
        }
    }
}
