using NCAAFRepository.Interface;
using System;
using System.Collections.Generic;
using NCAAFRankingViewer.SharedObjects;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

namespace NCAAFRepository.GetLatestRankings
{
    public class PullLatestRankingsFromWebRepository : ITeamRepository
    {
        Bitmap _bitmap = new Bitmap(400, 600);

        #region public fields
        public PullLatestRankingsFromWebRepository()
        {
        }

        public void AddCollege(CollegeTeams newCollege)
        {
            throw new NotImplementedException();
        }

        public void DeleteCollege(string teamName)
        {
            throw new NotImplementedException();
        }

        public CollegeTeams GetCollege(string teamName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CollegeTeams> GetColleges()
        {
            return GetWebsiteText();
        }

        public void UpdateCollege(string planetName, CollegeTeams updatedCollege)
        {
            throw new NotImplementedException();
        }

        public void UpdateColleges(List<CollegeTeams> updatedColleges)
        {
            throw new NotImplementedException();
        }

        public List<CollegeTeams> GetWebsiteText()
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://www.espn.com/college-football/rankings");
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();

            result = Regex.Replace(result, @"<^>*>", "^");
            return ExtractTeamsFromWebPage(result);
        }
        #endregion public fields

        #region private fields
        private List<CollegeTeams> ExtractTeamsFromWebPage(string result)
        {
            var rankingTeamPair = new List<string>();
            if (result.Contains("AP Top 25"))
            {
                var top25APPoll = GetTopAP25(result, rankingTeamPair);
            }
            else if (result.Contains("Coaches Poll"))
            {
                var top25CoachesPoll = GetCoachesPoll(result, rankingTeamPair);
            }
            else
            {
                return null;
            }
            return LoadCollegeTeams(rankingTeamPair);
        }

        private List<CollegeTeams> GetTopAP25(string result, List<string> rankingTeamPair)
        {
            using (StringReader reader = new StringReader(result))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("AP Top 25"))
                    {
                        string getRanking = "<span class=\"number\">(.*?)<\\/span>";
                        Regex regexRanking = new Regex(getRanking, RegexOptions.Singleline);
                        MatchCollection rankingCollection = regexRanking.Matches(line);

                        for (int i = 0; i < rankingCollection.Count; i++)
                        {
                            string rankCollegeName = "<span class=\"team-names\">(.*?)<\\/span>";
                            Regex rankName = new Regex(rankCollegeName, RegexOptions.Singleline);
                            MatchCollection rankingCollangeName = rankName.Matches(line);
                            string formatNames = rankingCollangeName[i].ToString().Replace("<span class=\"team-names\">", "");
                            formatNames = formatNames.Replace("</span>", "");                           

                            rankingTeamPair.Add((i + 1).ToString() + "^" + formatNames + "^" + GetCollegeLogos(line, i));
                        }
                    }
                }
                return LoadCollegeTeams(rankingTeamPair);
            }
        }
        
        private List<CollegeTeams> GetCoachesPoll(string result, List<string> rankingTeamList)
        {
            using (StringReader reader = new StringReader(result))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("Coaches Poll"))
                    {
                        string getRanking = "<span class=\"number\">(.*?)<\\/span>";
                        Regex regexRanking = new Regex(getRanking, RegexOptions.Singleline);
                        MatchCollection rankingCollection = regexRanking.Matches(line);

                        for (int i = 0; i < rankingCollection.Count; i++)
                        {
                            string rankCollegeName = "<span class=\"team-names\">(.*?)<\\/span>";
                            Regex rankCollageName = new Regex(rankCollegeName, RegexOptions.Singleline);
                            MatchCollection rankingCollangeName = rankCollageName.Matches(line);
                            string formatNames = rankingCollangeName[i].ToString().Replace("<span class=\"team-names\">", "");
                            formatNames = formatNames.Replace("</span>", "");

                            rankingTeamList.Add((i + 1).ToString() + "^" + formatNames);
                        }
                    }
                }
                return LoadCollegeTeams(rankingTeamList);
            }
        }

        public static string GetCollegeLogos(string line, int rating)
        {            
            string collegeLogo = "<img\\s[^>]*?src\\s*=\\s*['\"]([^'\"]*?)['\"][^>]*?>";
            Regex parseLogo = new Regex(collegeLogo, RegexOptions.Singleline);
            MatchCollection rankingCollangeLogo = parseLogo.Matches(line);
            string Logo = rankingCollangeLogo[rating].ToString().Replace("<img src=", "");
            Logo = Logo.Replace(">", "").Trim('"');
            return Logo;
        }

        private List<CollegeTeams> LoadCollegeTeams(List<string> rankingTeamPair)
         {            
            var collegeTeams = new List<CollegeTeams>();
            {
                foreach (var team in rankingTeamPair)
                {
                    string[] teamDetails = team.Split('^');
                    collegeTeams.Add(
                        new CollegeTeams() { CollegeRanking = Convert.ToInt32(teamDetails[0]), CollegeTeamName = teamDetails[1], CollegeLocation = GetCollegeLocation(teamDetails[1].ToString()), CollegeIcon = teamDetails[2].ToString(), DateOfRanking = DateTime.Now.ToString("MMMM-YY-dd") }
                    );                    
                }
            };                             
            return collegeTeams;
        }
                
        private string GetCollegeLocation(string value)
        {            
            if (value.Contains("Alabama"))
            {
                return "Tuscaloosa, AL";
            }
            else if (value.Contains("Oklahoma"))
            {
                return "Norman, OK";
            }
            else if (value.Contains("Clemson"))
            {
                return "Clemson, SC";
            }
            else if (value.Contains("Penn"))
            {
                return "State College";
            }
            else if (value.Contains("USC"))
            {
                return "Los Angeles, CA";
            }
            else if (value.Contains("Washington"))
            {
                return "Seattle, WA";
            }
            else if (value.Contains("Michigan"))
            {
                return "ANN ARBOR, MI";
            }
            else if (value.Contains("Ohio"))
            {
                return "Who Cares! OVERRATED!";
            }
            else if (value.Contains("Wisconsin"))
            {
                return "Madison, WI";
            }
            else if (value.Contains("Florida State"))
            {
                return "Tallahassee, FL";
            }
            else if (value == "Florida")
            {
                return "Gainsville, FL";
            }
            else
            {
                return "Location Unknown!";
            }
        }        
        #endregion private fields
    }
}

