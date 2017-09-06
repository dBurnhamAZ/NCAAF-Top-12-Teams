using Moq;
using NCAAFRankingViewer.SharedObjects;
using NCAAFRepository.Service.ServiceReference1;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using NCAAFRepository.Service;

namespace NCAAFTeamViewer.Presentation
{
    public class ServiceRepositoryTests
    {
        INCAAFLatestRankings _service;
        
        public void SetUp()
        {
            var Teams = new List<CollegeTeams>()
            {
                    new CollegeTeams() { CollegeTeamName = "Florida State", CollegeLocation = "Tallahassee, FL", CollegeRanking = 3 },
                    new CollegeTeams() { CollegeTeamName = "USC", CollegeLocation = "Los Angeles, CA", CollegeRanking = 4 },
                    new CollegeTeams() { CollegeTeamName = "Clemson", CollegeLocation = "Clemson, SC", CollegeRanking = 5 },
            };
            var svcMock = new Mock<INCAAFLatestRankings>();
            svcMock.Setup(r => r.GetColleges()).Returns(Teams);

            svcMock.Setup(r => r.GetCollege(It.IsAny<string>())).Returns((string n) => Teams.FirstOrDefault(t => t.CollegeTeamName == n));

            _service = svcMock.Object;
        }

        [Fact]
        public void GetTeamsOnExecute_ReturnsTeams()
        {
            SetUp();
            //arrange
            var repo = new ServiceRepository();
            repo.ServiceProxy = _service;

            //Act
            var output = repo.GetColleges();

            //assert
            Assert.NotNull(output);
            Assert.Equal(3, output.Count());
        }

        [Fact]
        public void GetTeamOnExecute_ReturnsTeamMyTeam()
        {
            SetUp();
            //arrange
            var repo = new ServiceRepository();
            repo.ServiceProxy = _service;

            //Act
            var output = repo.GetCollege("Clemson");

            //assert
            Assert.NotNull(output);
            Assert.Equal("Clemson", output.CollegeTeamName);
        }

        [Fact]
        public void GetTeamOnExecute_ReturnsNoNames()
        {
            SetUp();
            //arrange
            var repo = new ServiceRepository();
            repo.ServiceProxy = _service;

            //Act
            var output = repo.GetCollege("Not A Real College");

            //assert
            Assert.Null(output);
        }

    }
}
