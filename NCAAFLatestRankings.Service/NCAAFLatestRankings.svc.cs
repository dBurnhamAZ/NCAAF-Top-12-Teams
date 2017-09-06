using System;
using System.Collections.Generic;
using System.Linq;
using NCAAFRankingViewer.SharedObjects;
using System.Windows.Media.Imaging;

namespace NCAAFLatestRankings.Service
{
    public class Service1 : INCAAFLatestRankings
    {
        public CollegeTeams GetCollege(string teamName)
        {
            var collegeTeam = new List<CollegeTeams>()
            {
                new CollegeTeams() { CollegeTeamName="Alabama", CollegeLocation="Tuscaloosa, AL", CollegeRanking = 1, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/bama.png", UriKind.Relative) },
                //new CollegeTeams() { CollegeTeamName="Ohio State", CollegeLocation="Who Cares! OVERRATED!", CollegeRanking = 2, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/osu.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Clemson", CollegeLocation="Clemson, SC", CollegeRanking = 3, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/clemson.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Penn State", CollegeLocation="State College, PA", CollegeRanking = 4, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/psu.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Oklahoma", CollegeLocation="Norman, OK", CollegeRanking = 5, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/oku.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="USC", CollegeLocation="Los Angeles, CA", CollegeRanking = 6, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/usc.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Washington", CollegeLocation="Seattle, WA", CollegeRanking = 7, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/washu.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="MICHIGAN", CollegeLocation="ANN ARBOR, MI", CollegeRanking = 8, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/MICH.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Winconsin", CollegeLocation="Madison, WI", CollegeRanking = 9, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/wisconu.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Florida State", CollegeLocation="Tallahassee, FL", CollegeRanking = 10, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/fsu.png", UriKind.Relative) },
            };
            CollegeTeams getTeamName = collegeTeam.Where(t => t.CollegeTeamName == teamName).FirstOrDefault();
            return getTeamName;
        }

        public List<CollegeTeams> GetColleges()
        {
            var collegeTeams = new List<CollegeTeams>()
            {
                new CollegeTeams() { CollegeTeamName="Alabama", CollegeLocation="Tuscaloosa, AL", CollegeRanking = 1, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/bama.png", UriKind.Relative) },
                //new CollegeTeams() { CollegeTeamName="Ohio State", CollegeLocation="Who Cares! OVERRATED!", CollegeRanking = 2, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/osu.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Clemson", CollegeLocation="Clemson, SC", CollegeRanking = 3, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/clemson.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Penn State", CollegeLocation="State College, PA", CollegeRanking = 4, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/psu.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Oklahoma", CollegeLocation="Norman, OK", CollegeRanking = 5, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/oku.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="USC", CollegeLocation="Los Angeles, CA", CollegeRanking = 6, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/usc.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Washington", CollegeLocation="Seattle, WA", CollegeRanking = 7, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/washu.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="MICHIGAN", CollegeLocation="ANN ARBOR, MI", CollegeRanking = 8, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/MICH.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Winconsin", CollegeLocation="Madison, WI", CollegeRanking = 9, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/wisconu.png", UriKind.Relative) },
                new CollegeTeams() { CollegeTeamName="Florida State", CollegeLocation="Tallahassee, FL", CollegeRanking = 10, DateOfRanking = new DateTime(2017, 9, 1), CollegeIcon = new Uri(@"Images/fsu.png", UriKind.Relative) },
            };
            return collegeTeams;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
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
    }
}
