using System;
using System.Windows.Media.Imaging;

namespace NCAAFRankingViewer.SharedObjects
{
    public class CollegeTeams
    {
        public string CollegeTeamName { get; set; }

        public string CollegeLocation { get; set; }

        public int CollegeRanking { get; set; }

        public Uri CollegeIcon { get; set; }

        public DateTime DateOfRanking { get; set; }
    }
}
