using Moq;
using NCAAFRankingViewer.SharedObjects;
using NCAAFRepository.Interface;
using NCAAFTeamViewer.Presentation;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NCAAFUnitTests
{
    public class NCAAFTeamViewViewModelTest
    {
        ITeamRepository _repository;
        public void SetUp()
        {
            var Teams = new List<CollegeTeams>()
            {
                    new CollegeTeams() { CollegeTeamName = "Florida State", CollegeLocation = "Tallahassee, FL", CollegeRanking = 3 },
                    new CollegeTeams() { CollegeTeamName = "USC", CollegeLocation = "Los Angeles, CA", CollegeRanking = 4 },
                    new CollegeTeams() { CollegeTeamName = "Clemson", CollegeLocation = "Clemson, SC", CollegeRanking = 5 },
            };
            var repoMock = new Mock<ITeamRepository>();
            repoMock.Setup(r => r.GetColleges()).Returns(Teams);
            _repository = repoMock.Object;
        }
        
        [Fact]
        public void TeamsOnRefeshCommand_IsPopulated()
        {
            //arrange
            SetUp();
            var vm = new TeamViewViewModel(_repository);
            //act
            vm.RefreshTeamCommand.Execute(null);
            //assert
            Assert.NotNull(vm.Teams);
            Assert.Equal(3, vm.Teams.Count());
        }

        [Fact]
        public void TeamsOnClearCommand_IsEmpty()
        {
            //arrange
            SetUp();
            var vm = new TeamViewViewModel(_repository);
            //act
            vm.ClearTeamCommand.Execute(null);
            //assert
            Assert.NotNull(vm.Teams);
            Assert.Equal(0, vm.Teams.Count());
        }
    }
}
