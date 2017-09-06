using System;
using System.Collections.Generic;
using NCAAFRankingViewer.SharedObjects;
using NCAAFRepository.Interface;
using System.IO;
using System.Windows.Media.Imaging;
using System.Configuration;

namespace NCAAFRepository.CSV
{
    public class CSVRepository : ITeamRepository
    {
        string path;

        public CSVRepository()
        {
            var filename = ConfigurationManager.AppSettings["CSVFileName"];
            path = AppDomain.CurrentDomain.BaseDirectory + filename;
        }

        public IEnumerable<CollegeTeams> GetColleges()
        {
            var teams = new List<CollegeTeams>();

            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var elems = line.Split(',');
                        string stringPath = elems[3].ToString();
                        Uri imageUri = new Uri(stringPath, UriKind.Relative);
                        //BitmapImage imageBitmap = new BitmapImage(imageUri);
                        var team = new CollegeTeams()
                        {
                            CollegeTeamName = elems[0],
                            CollegeLocation = elems[1],
                            CollegeRanking = Int32.Parse(elems[2]),
                            CollegeIcon = imageUri
                        };
                        teams.Add(team);
                    }
                }
            }
            return teams;
        }

        public CollegeTeams GetCollege(string teamName)
        {
            var team = new CollegeTeams();

            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var elems = line.Split(',');
                        string stringPath = elems[3].ToString();
                        Uri imageUri = new Uri(stringPath, UriKind.Relative);
                        BitmapImage imageBitmap = new BitmapImage(imageUri);
                        var teamInfo = new CollegeTeams()
                        {
                            CollegeTeamName = elems[0],
                            CollegeLocation = elems[1],
                            CollegeRanking = Int32.Parse(elems[2]),
                            CollegeIcon = imageUri,
                            DateOfRanking = DateTime.Parse(elems[5])
                        };
                    }
                }
            }
            return team;
        }

        public void AddCollege(CollegeTeams newCollege)
        {
            throw new NotImplementedException();
        }

        public void DeleteCollege(string teamName)
        {
            throw new NotImplementedException();
        }

        public void UpdateCollege(string planetName, CollegeTeams updatedCollege)
        {
            throw new NotImplementedException();
        }

        public void UpdateColleges(List<CollegeTeams> updatedColleges)
        {
            throw new NotImplementedException();
        }
    }
}
