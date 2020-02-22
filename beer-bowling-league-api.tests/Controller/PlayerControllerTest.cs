using AutoMapper;
using beer_bowling_league_api.Contracts.Responses;
using beer_bowling_league_api.Contracts;
using beer_bowling_league_api.Controllers;
using beer_bowling_league_api.Entity;
using beer_bowling_league_api.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace beer_bowling_league_api.tests.Controller
{
    
    public class PlayerControllerTest
    {
        private readonly IMapper _mapper;

        public PlayerControllerTest()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMappingProfile());
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task GetAll_WithPlayersStoredInDatabase_ReturnsResponse200OkWithAllPlayers()
        {
            // Given
            var mockPlayerRepo = new Mock<IPlayerService>();
            mockPlayerRepo.Setup(repo => repo.GetPlayersAsync())
                .Returns(GetPlayersAsync());
            
            var controller = new PlayerController(_mapper, mockPlayerRepo.Object);

            // When 
            var response = await controller.GetAll() as OkObjectResult;            

            // Then
            response.StatusCode.Should().Be(HttpStatusCode.OK.GetHashCode());
            
            var playerList = response.Value as IEnumerable<PlayerResponseDto>;
            playerList.Count().Should().Be(3);

            playerList.ElementAt(0).Age.Should().Be(1);
            playerList.ElementAt(0).FirstName.Should().Be("John1");
            playerList.ElementAt(0).LastName.Should().Be("Doe1");
            playerList.ElementAt(0).Alias.Should().Be("Doozer1");            
            playerList.ElementAt(1).Age.Should().Be(2);
            playerList.ElementAt(2).Age.Should().Be(3);
        }

        [Fact]
        public async Task GetAll_WithNoPlayersStoredInDatabase_ReturnsResponseNotFound()
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
        public async Task GetAll_PlayerServiceResponseIsNull_ReturnsResponseNotFound()
        {
            // Given
            var mockedPlayerService = new Mock<IPlayerService>();
            mockedPlayerService.Setup(repo => repo.GetPlayersAsync())
                .Returns(Task.FromResult<List<Player>>(null));

            var controller = new PlayerController(_mapper, mockedPlayerService.Object);

            // When 
            var response = await controller.GetAll() as NotFoundResult;

            // Then
            mockedPlayerService.Verify(p => p.GetPlayersAsync());
            response.StatusCode.Should().Be(HttpStatusCode.NotFound.GetHashCode());
        }

        private Task<List<Player>> GetPlayersAsync()
        {
            List<Player> playerList = new List<Player>();
            
            for (int i = 1; i < 4; i++)
            {
                var player = new Player()
                {
                    Id = Guid.NewGuid(),
                    Age = i,
                    FirstName = "John" + i,
                    LastName = "Doe" + i,
                    Alias = "Doozer" + i,
                    BirthDay = new DateTime(1986,i,i)
                };
                playerList.Add(player);
            }

            return Task.FromResult(playerList);
        }

        private Task<List<Player>> GetEmptyPlayerListsAsync()
        {
            List<Player> playerList = new List<Player>();

            return Task.FromResult(playerList);
        }
    }
}
