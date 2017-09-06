using Microsoft.Practices.Unity;
using Moq;
using NCAAFRankingViewer.SharedObjects;
using NCAAFRepository.Interface;
using NCAAFTeamViewer.Presentation;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NCAAFUnitTests
{
    public class UnityCollegeTeamsViewViewModelTest
    {
        IUnityContainer _container;

        public void SetUp()
        {
            var Teams = new List<CollegeTeams>()
            {
                    new CollegeTeams() { CollegeTeamName = "Florida State", CollegeLocation = "Tallahassee, FL", CollegeRanking = 3 },
                    new CollegeTeams() { CollegeTeamName = "USC", CollegeLocation = "Los Angeles, CA", CollegeRanking = 4 },
                    new CollegeTeams() { CollegeTeamName = "Clemson", CollegeLocation = "Clemson, SC", CollegeRanking = 5 },
            };
            var unityMock = new Mock<ITeamRepository>();
            unityMock.Setup(r => r.GetColleges()).Returns(Teams);

            unityMock.Setup(r => r.GetCollege(It.IsAny<string>())).Returns((string n) => Teams.FirstOrDefault(t => t.CollegeTeamName == n));
            _container = new UnityContainer();
            _container.RegisterInstance<ITeamRepository>(unityMock.Object);
        }

        [Fact]
        public void UnityTeamsOnRefeshCommand_IsPopulated()
        {
            //arrange
            SetUp();            
            var vm = _container.Resolve<TeamViewViewModel>();
            //act
            vm.RefreshTeamCommand.Execute(null);
            //assert
            Assert.NotNull(vm.Teams);
            Assert.Equal(3, vm.Teams.Count());
        }

        [Fact]
        public void UnityTeamsOnClearCommand_IsEmpty()
        {
            //arrange
            SetUp();
            var vm = _container.Resolve<TeamViewViewModel>();
            //act
            vm.ClearTeamCommand.Execute(null);
            //assert
            Assert.NotNull(vm.Teams);
            Assert.Equal(0, vm.Teams.Count());
        }
    }
}
