using IoCCustomContainer.InterfaceContainer;
using NCAAFRepository.CSV;
using NCAAFRepository.GetLatestRankings;
using NCAAFRepository.Interface;
using NCAAFRepository.Service;
using NCAAFTeamViewer.Presentation;
using System;
using System.Windows;

namespace TeamView.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IContainer container = new IoCCustomContainer.Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Title = "Loose Coupling - Team Viewer";
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// App.xaml.cs will control the OnStart injection.
        /// In this example, all we have to do is unComment the Repository class
        /// for any desired repository on start-up.
        /// This example has options of running a Service (WCF), a CSV file, or
        /// updated values directly from a NCAA Standings Webpage. 
        /// The purpose of this app is to demo a simple wrapper, a custom container, a Unity container,  
        /// and Depenency Injection.
        /// By seperating each layer, we can use Interfaces for communications
        /// and Unit Testing
        /// </summary>
        private void ConfigureContainer()
        {              
            Console.WriteLine("testing instance type resigtration for class");
            
            // testing instance type resigtration for NCAA Website
            container.RegisterInstanceType<ITeamRepository, PullLatestRankingsFromWebRepository>();

            // testing instance type resigtration for Service (Singleton)
            //container.RegisterSingletonType<ITeamRepository, ServiceRepository>();

            // testing instance type resigtration for CSV (Transient)
            //container.RegisterInstanceType<ITeamRepository, CSVRepository>();
        }

        private void ComposeObjects()
        {
            Console.WriteLine("testing instance type resigtration for Main Window");
            ITeamRepository repository = container.Resolve<ITeamRepository>();
            TeamViewViewModel viewModel = new TeamViewViewModel(repository);
            Application.Current.MainWindow = new TeamViewWindow(viewModel);
            if (repository.GetType().Name == "CSVRepository")
            {
                viewModel.Repository = "CSVRepository";
            }
            else if (repository.GetType().Name == "ServiceRepository")
            {
                viewModel.Repository = "ServiceRepository";
            }
            else if (repository.GetType().Name == "PullLatestRankingsFromWebRepository")
            {
                viewModel.Repository = "WebsiteRepository";
            }
        }
    }
}
