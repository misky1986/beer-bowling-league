using AutoMapper;
using beer_bowling_league_api.Contracts;
using beer_bowling_league_api.Contracts.Responses;
using beer_bowling_league_api.Controllers;
using beer_bowling_league_api.Service;
using beer_bowling_league_api.tests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace beer_bowling_league_api.tests.UnitTest.Controller
{

    public class PlayerControllerUnitTests : UnitTestUtilities
    {
        private readonly IMapper _mapper;

        public PlayerControllerUnitTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMappingProfile());
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task GetAllPlayers_WithPlayersStoredInDatabase_ReturnsResponse200OkWithAllPlayers()
        {
            // Given
            var mockPlayerService = new Mock<IPlayerService>();
            mockPlayerService.Setup(repo => repo.GetPlayersAsync())
                .Returns(GetPlayersMockedAsync());
            
            var controller = new PlayerController(_mapper, mockPlayerService.Object);

            // When 
            var response = await controller.GetAll() as OkObjectResult;            

            // Then
            response.StatusCode.Should().Be(HttpStatusCode.OK.GetHashCode());
            
            var playerList = response.Value as IEnumerable<PlayerResponseDto>;
            playerList.Count().Should().Be(3);

            playerList.ElementAt(0).Age.Should().Be(1);
            playerList.ElementAt(0).FirstName.Should().Be("John1");
            playerList.ElementAt(0).LastName.Should().Be("Doe1");
            playerList.ElementAt(0).Alias.Should().Be("Dooezer1");            
            playerList.ElementAt(1).Age.Should().Be(2);
            playerList.ElementAt(2).Age.Should().Be(3);
        }

        [Fact]
        public async Task GetAllPlayers_WithNoPlayersStoredInDatabase_ReturnsResponseNotFound()
        {
            // Given
            var mockedPlayerService = new Mock<IPlayerService>();
            mockedPlayerService.Setup(repo => repo.GetPlayersAsync())
                .Returns(GetEmptyPlayerListsAsync());

            var controller = new PlayerController(_mapper, mockedPlayerService.Object);

            // When 
            var response = await controller.GetAll() as NotFoundResult;

            // Then
            mockedPlayerService.Verify(p => p.GetPlayersAsync());
            response.StatusCode.Should().Be(HttpStatusCode.NotFound.GetHashCode());
        }
        
        [Fact]
        public async Task GetAllPlayers_PlayerServiceResponseIsNull_ReturnsResponseNotFound()
        {
            // Given
            var mockedPlayerService = new Mock<IPlayerService>();
            mockedPlayerService.Setup(repo => repo.GetPlayersAsync())
                .Returns(Task.FromResult<IEnumerable<PlayerResponseDto>>(null));

            var controller = new PlayerController(_mapper, mockedPlayerService.Object);

            // When 
            var response = await controller.GetAll() as NotFoundResult;

            // Then
            mockedPlayerService.Verify(p => p.GetPlayersAsync());
            response.StatusCode.Should().Be(HttpStatusCode.NotFound.GetHashCode());
        }        
    }
}
