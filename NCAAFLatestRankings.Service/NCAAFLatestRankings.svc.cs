using System;
using System.Collections.Generic;
using System.Linq;
using NCAAFRankingViewer.SharedObjects;

namespace NCAAFLatestRankings.Service
{
    public class Service1 : INCAAFLatestRankings
    {
        #region public fields
        public CollegeTeams GetCollege(string teamName)
        {
            List<CollegeTeams> collegeTeam = LoadCollegeTeams();
            CollegeTeams getTeamName = collegeTeam.Where(t => t.CollegeTeamName == teamName).FirstOrDefault();
            return getTeamName;
        }

        public List<CollegeTeams> GetColleges()
        {
            return LoadCollegeTeams();
        }

        public string GetData(int value)
        {
            return string.Format($"You entered: {value}");
        }

        public void UpdateCollege(string planetName, CollegeTeams updatedCollege)
        {
            throw new NotImplementedException();
        }

        public void UpdateColleges(List<CollegeTeams> updatedColleges)
        {
            throw new NotImplementedException();
        }
        public void AddCollege(CollegeTeams newCollege)
        {
            throw new NotImplementedException();
        }

        public void DeleteCollege(string teamName)
        {
            throw new NotImplementedException();
        }
        #endregion public fields

        #region private fields
        private static List<CollegeTeams> LoadCollegeTeams()
        {
            var collegeTeam = new List<CollegeTeams>()
            {
                new CollegeTeams() { CollegeTeamName="Alabama", CollegeLocation="Data from Server", CollegeRanking = 1, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName = "Clemson", CollegeLocation = "Data from Server", CollegeRanking = 2, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName = "Penn State", CollegeLocation = "Data from Server", CollegeRanking = 3, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName = "Oklahoma", CollegeLocation = "Data from Server", CollegeRanking = 4, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName = "USC", CollegeLocation = "Data from Server", CollegeRanking = 5, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName = "Washington", CollegeLocation = "Data from Server", CollegeRanking = 6, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName = "MICHIGAN", CollegeLocation = "Data from Server", CollegeRanking = 7, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName = "Winconsin", CollegeLocation = "Data from Server", CollegeRanking = 8, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName="Ohio State", CollegeLocation="Who Cares! OVERRATED!", CollegeRanking = 9, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName = "Florida State", CollegeLocation = "Data from Server", CollegeRanking = 10, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },                
            };
            return collegeTeam;
        }
        #endregion private fields
    }
}
