using IoCCustomContainer.InterfaceContainer;
using Moq;
using NCAAFRankingViewer.SharedObjects;
using NCAAFRepository.Interface;
using NCAAFRepository.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NCAAFUnitTests
{
    public class CustomIoCContainerRepositoryTests
    {
        IContainer _container;
        ITeamRepository _repository;

        public void SetUp()
        {
            var Teams = new List<CollegeTeams>()
            {
                new CollegeTeams() { CollegeTeamName="Alabama", CollegeLocation="Data from Server", CollegeRanking = 1, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName = "Clemson", CollegeLocation = "Data from Server", CollegeRanking = 2, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
                new CollegeTeams() { CollegeTeamName = "MICHIGAN", CollegeLocation = "Data from Server", CollegeRanking = 3, DateOfRanking = "2017, 9, 1", CollegeIcon = string.Empty },
            };

            var customMock = new Mock<ITeamRepository>();

            customMock.Setup(r => r.GetColleges()).Returns(Teams);

            customMock.Setup(r => r.GetCollege(It.IsAny<string>())).Returns((string n) => Teams.FirstOrDefault(t => t.CollegeTeamName == n));
            
            _repository = customMock.Object;
        }


        [Fact]
        public void CustomTeamsOnExecuteWithValidName_IsPopulated()
        {
            //act
            _container = new IoCCustomContainer.Container();
            _container.RegisterInstanceType<ITeamRepository, ServiceRepository>();

            SetUp();

            ITeamRepository repo = _container.Resolve<ITeamRepository>();

            //arrange            
            repo = _repository;

            //act
            var output = repo.GetColleges();

            //assert
            Assert.NotNull(output);
            Assert.Equal(3, output.Count());
        }

        [Fact]
        public void CustomGetTeamOnExecuteWithMyTeamName()
        {
            //act
            _container = new IoCCustomContainer.Container();
            _container.RegisterInstanceType<ITeamRepository, ServiceRepository>();

            SetUp();

            ITeamRepository repo = _container.Resolve<ITeamRepository>();

            //arrange            
            repo = _repository;

            //act
            var output = repo.GetCollege("MICHIGAN");

            //assert
            Assert.NotNull(output);
            Assert.Equal("MICHIGAN", output.CollegeTeamName);
        }

        [Fact]
        public void CustomGetTeamOnExecuteWithUnknownName()
        {
            //act
            _container = new IoCCustomContainer.Container();
            _container.RegisterInstanceType<ITeamRepository, ServiceRepository>();

            SetUp();

            ITeamRepository repo = _container.Resolve<ITeamRepository>();

            //arrange            
            repo = _repository;            
            var output = repo.GetCollege("Not A Real College");

            //assert
            Assert.Null(output);
        }
    }
}
