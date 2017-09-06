using System.Collections.Generic;
using NCAAFRepository.Interface;
using System.Linq;
using NCAAFRankingViewer.SharedObjects;
using NCAAFRepository.Service.ServiceReference1;

namespace NCAAFRepository.Service
{
    public class ServiceRepository : ITeamRepository
    {
        private INCAAFLatestRankings _serviceProxy;
        public INCAAFLatestRankings ServiceProxy
        {
            get
            {
                if (_serviceProxy == null)
                    _serviceProxy = new NCAAFLatestRankingsClient();
                    return _serviceProxy;
            }
            set
            {
                if (_serviceProxy == value)
                    return;
                _serviceProxy = value;
            }
        }

        public void AddCollege(CollegeTeams newCollege)
        {
            ServiceProxy.AddCollege(newCollege);
        }

        public void DeleteCollege(string teamName)
        {
            ServiceProxy.DeleteCollege(teamName);
        }

        public CollegeTeams GetCollege(string teamName)
        {
            return ServiceProxy.GetCollege(teamName);
        }

        public IEnumerable<CollegeTeams> GetColleges()
        {
            return ServiceProxy.GetColleges();
        }

        public void UpdateCollege(string teamName, CollegeTeams updatedCollege)
        {
            ServiceProxy.UpdateCollege(teamName, updatedCollege);
        }

        public void UpdateColleges(List<CollegeTeams> updatedColleges)
        {
            ServiceProxy.UpdateColleges(updatedColleges.ToList());
        }
        
    }
}
