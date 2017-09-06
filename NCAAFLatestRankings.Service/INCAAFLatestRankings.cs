using NCAAFRankingViewer.SharedObjects;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace NCAAFLatestRankings.Service
{    
    [ServiceContract]
    public interface INCAAFLatestRankings
    {

        [OperationContract]
        string GetData(int value);
        
        [OperationContract]
        List<CollegeTeams> GetColleges();

        [OperationContract]
        CollegeTeams GetCollege(string teamName);

        [OperationContract]
        void AddCollege(CollegeTeams newCollege);

        [OperationContract]
        void UpdateCollege(string planetName, CollegeTeams updatedCollege);

        [OperationContract]
        void DeleteCollege(string teamName);

        [OperationContract]
        void UpdateColleges(List<CollegeTeams> updatedColleges);
    }    
}
