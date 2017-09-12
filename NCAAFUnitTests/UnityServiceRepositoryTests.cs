using Microsoft.Practices.Unity;
using Moq;
using NCAAFRankingViewer.SharedObjects;
using NCAAFRepository.Service;
using NCAAFRepository.Service.ServiceReference1;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NCAAFUnitTests
{
    public class UnityServiceRepositoryTests
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
            var unityMock = new Mock<INCAAFLatestRankings>();
            unityMock.Setup(r => r.GetColleges()).Returns(Teams);

            unityMock.Setup(r => r.GetCollege(It.IsAny<string>())).Returns((string n) => Teams.FirstOrDefault(t => t.CollegeTeamName == n));
            _container = new UnityContainer();
            _container.RegisterInstance<INCAAFLatestRankings>(unityMock.Object);
            _container.RegisterType<ServiceRepository>(new InjectionProperty("ServiceProxy"));
        }

        [Fact]
        public void UnityTeamsOnExecuteWithValidName_IsPopulated()
        {
            //arrange
            SetUp();
            var repo = _container.Resolve<ServiceRepository>();

            //act
            var output = repo.GetColleges();

            //assert
            Assert.NotNull(output);
            Assert.Equal(3, output.Count());
        }

        [Fact]
        public void UnityGetTeamOnExecuteWithInvalidName_IsEmpty()
        {
            SetUp();
            var repo = _container.Resolve<ServiceRepository>();

            //act
            var output = repo.GetCollege("No Name");

            //assert
            Assert.Null(output);
        }
    }
}
