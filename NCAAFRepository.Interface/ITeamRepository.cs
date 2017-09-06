using NCAAFRankingViewer.SharedObjects;
using System.Collections.Generic;

namespace NCAAFRepository.Interface
{
    public interface ITeamRepository
    {                
        IEnumerable<CollegeTeams> GetColleges();
        
        CollegeTeams GetCollege(string teamName);
        
        void AddCollege(CollegeTeams newCollege);
        
        void UpdateCollege(string planetName, CollegeTeams updatedCollege);
        
        void DeleteCollege(string teamName);
        
        void UpdateColleges(List<CollegeTeams> updatedColleges);
    }
}
