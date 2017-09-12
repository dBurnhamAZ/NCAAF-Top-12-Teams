using NCAAFRepository.CSV;
using NCAAFTeamViewer.Presentation;
using System.Windows;
using Microsoft.Practices.Unity;
using NCAAFRepository.Interface;
using NCAAFRepository.Service;
using NCAAFRepository.GetLatestRankings;

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

        /// <summary>
        /// App.xaml.cs will control the OnStart injection.
        /// In this example, all we have to do is use the RegisterType in Unity
        /// for any desired start-up.
        /// This example has options of running a Service (WCF), a CSV file, or
        /// updated values directly from a NCAA Standings Webpage. 
        /// The purpose of this app is to demo decoupling and Depenency Injection
        /// By seperating each layer, we can use Interfaces for communications
        /// and Unit Testing
        /// </summary>
        private void ConfigureContainer()
        {
            container = new UnityContainer();

            //default Transiet Registered Type
            //CSVRepository
            //container.RegisterType<ITeamRepository, CSVRepository>(default(TransientLifetimeManager));
            //ServiceRepository
            //container.RegisterType<ITeamRepository, ServiceRepository>(default(TransientLifetimeManager));
            //NCAA WebsiteRepository
            container.RegisterType<ITeamRepository, PullLatestRankingsFromWebRepository>(default(TransientLifetimeManager));

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
