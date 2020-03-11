﻿using AutoMapper;
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
    public class TeamControllerUnitTests : UnitTestUtilities
    {
        private readonly IMapper _mapper;

        public TeamControllerUnitTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMappingProfile());
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task GetAllTeams_WithTeamsStoredInDatabase_ReturnsResponse200OkWithAllPlayers()
        {
            // Given
            var mockedTeamService = new Mock<ITeamService>();
            mockedTeamService.Setup(repo => repo.GetTeamsAsync())
                .Returns(GetTeamsMockedAsync());

            var controller = new TeamController(_mapper, mockedTeamService.Object);

            // When 
            var response = await controller.GetAll() as OkObjectResult;

            // Then
            response.StatusCode.Should().Be(HttpStatusCode.OK.GetHashCode());

            var teamList = response.Value as IEnumerable<TeamResponseDto>;
            teamList.Count().Should().Be(4);                             
        }

        [Fact]
        public async Task GetAllTeams_WithNoTeamsStoredInDatabase_ReturnsResponseNotFound()
        {
            // Given
            var mockedTeamService = new Mock<ITeamService>();
            mockedTeamService.Setup(repo => repo.GetTeamsAsync())
                .Returns(GetEmptyTeamListsAsync());

            var controller = new TeamController(_mapper, mockedTeamService.Object);

            // When 
            var response = await controller.GetAll() as NotFoundResult;

            // Then
            mockedTeamService.Verify(p => p.GetTeamsAsync());
            response.StatusCode.Should().Be(HttpStatusCode.NotFound.GetHashCode());
        }

        [Fact]
        public async Task GetAllTeams_ServiceResponseIsNull_ReturnsResponseNotFound()
        {
            // Given
            var mockedTeamService = new Mock<ITeamService>();
            mockedTeamService.Setup(repo => repo.GetTeamsAsync())
                .Returns(Task.FromResult<IEnumerable<TeamResponseDto>>(null));

            var controller = new TeamController(_mapper, mockedTeamService.Object);

            // When 
            var response = await controller.GetAll() as NotFoundResult;

            // Then
            mockedTeamService.Verify(p => p.GetTeamsAsync());
            response.StatusCode.Should().Be(HttpStatusCode.NotFound.GetHashCode());
        }

    }
}
