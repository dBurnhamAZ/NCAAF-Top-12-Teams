using NCAAFRepository.CSV;
using NCAAFTeamViewer.Presentation;
using System.Windows;
using Microsoft.Practices.Unity;
using NCAAFRepository.Interface;
using NCAAFRepository.Service;

namespace TeamView.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IUnityContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();            
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            container = new UnityContainer();
            //default Transiet Registered Type
            container.RegisterType<ITeamRepository, CSVRepository>(default(TransientLifetimeManager));
            //set Singleton Registered Type
            //container.RegisterType<ITeamRepository, CSVRepository>(new ContainerControlledLifetimeManager());
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = container.Resolve<TeamViewWindow>();
            Application.Current.MainWindow.Title = "Loose Coupling - Team Viewer";
        }
    }
}
