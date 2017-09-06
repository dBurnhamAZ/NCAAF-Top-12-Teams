using NCAAFRankingViewer.SharedObjects;
using NCAAFRepository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace NCAAFTeamViewer.Presentation
{
    public class TeamViewViewModel : INotifyPropertyChanged
    {
        protected ITeamRepository _repository;

        public TeamViewViewModel(ITeamRepository repository)
        {
            _repository = repository;
        }

        private IEnumerable<CollegeTeams> _teams;
        public IEnumerable<CollegeTeams> Teams
        {
            get { return _teams; }
            set
            {
                if (_teams == value)
                    return;
                _teams = value;
                RaisePropertyChanged("Teams");
            }
        }

        #region RefreshCommand
        private RefreshCommand _refreshTeamCommand = new RefreshCommand();
        public RefreshCommand RefreshTeamCommand
        {
            get
            {
                if (_refreshTeamCommand.RefreshTeamViewModel == null)
                    _refreshTeamCommand.RefreshTeamViewModel = this;
                return _refreshTeamCommand;
            }
        }

        public class RefreshCommand : ICommand
        {
            public TeamViewViewModel RefreshTeamViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }            

            public void Execute(object parameter)
            {
                RefreshTeamViewModel.Teams = RefreshTeamViewModel._repository.GetColleges();
            }
        }
        #endregion RefreshCommand

        #region ClearCommand
        private ClearCommand _clearTeamCommand = new ClearCommand();
        public ClearCommand ClearTeamCommand
        {
            get
            {
                if (_clearTeamCommand.ClearTeamViewModel == null)
                    _clearTeamCommand.ClearTeamViewModel = this;
                return _clearTeamCommand;
            }
        }

        public class ClearCommand : ICommand
        {
            public TeamViewViewModel ClearTeamViewModel { get; set; }
            public event EventHandler CanExecuteChanged;
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                ClearTeamViewModel.Teams = new List<CollegeTeams>();
            }
        }
        #endregion ClearCommand

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
