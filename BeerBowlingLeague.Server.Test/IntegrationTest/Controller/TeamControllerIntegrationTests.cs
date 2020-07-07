using BeerBowlingLeague.Server.Contracts;
using BeerBowlingLeague.Server.Contracts.Responses;
using BeerBowlingLeague.Server.DataAccess;
using BeerBowlingLeague.Server.Tests.Helpers;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace BeerBowlingLeague.Server.Tests.IntegrationTest.Controller
{
    public class TeamControllerIntegrationTests : IClassFixture<InMemoryApplicationFactory<Startup>>, IDisposable
    {
        private readonly InMemoryApplicationFactory<Startup> _factory;
        private HttpClient TestClient;

        public TeamControllerIntegrationTests(InMemoryApplicationFactory<Startup> factory)
        {
            _factory = factory;
            IntegrationTestUtilities.EnsureDatabaseCreated(_factory);
            //ApplicationDbContext applicationDbContext = _factory.Services.GetRequiredService<ApplicationDbContext>();
            //applicationDbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            //ApplicationDbContext applicationDbContext = _factory.Services.GetRequiredService<ApplicationDbContext>();
            //applicationDbContext.Database.EnsureDeleted();
            IntegrationTestUtilities.EnsureDatabaseDeleted(_factory);
        }

        [Fact]        
        public async Task GetAll_WithoutAnyPosts_ReturnsEmptyResponse()
        {
            // Arrange
            TestClient = _factory.CreateClient();
            var jsonSerializeOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Teams.GetAll);
            var deserializedResponse = await JsonSerializer.DeserializeAsync<List<TeamResponseDto>>(await response.Content.ReadAsStreamAsync(), jsonSerializeOptions);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            deserializedResponse.Count.Should().Be(4);
        }
    }
}
