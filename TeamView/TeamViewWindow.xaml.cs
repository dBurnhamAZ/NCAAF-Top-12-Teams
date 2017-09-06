using NCAAFTeamViewer.Presentation;
using System.Windows;

namespace TeamView.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TeamViewWindow : Window
    {
        public TeamViewWindow(TeamViewViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
