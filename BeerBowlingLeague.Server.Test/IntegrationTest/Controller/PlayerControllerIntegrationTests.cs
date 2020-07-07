using BeerBowlingLeague.Server.Contracts;
using BeerBowlingLeague.Server.Contracts.Requests;
using BeerBowlingLeague.Server.Contracts.Responses;
using BeerBowlingLeague.Server.DataAccess;
using BeerBowlingLeague.Server.Tests.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace BeerBowlingLeague.Server.Tests.IntegrationTest.Controller
{
    public class PlayerControllerIntegrationTests : IClassFixture<InMemoryApplicationFactory<Startup>>, IDisposable
    {
        private readonly InMemoryApplicationFactory<Startup> _factory;
        private HttpClient TestClient;

        public PlayerControllerIntegrationTests(InMemoryApplicationFactory<Startup> factory)
        {
            _factory = factory;
            IntegrationTestUtilities.EnsureDatabaseCreated(_factory);
        }

        public void Dispose()
        {
            IntegrationTestUtilities.EnsureDatabaseDeleted(_factory);
        }

        [Fact]
        public async Task GetAll_WithoutAnyPosts_ReturnsEmptyResponse()
        {
            // Arrange
            TestClient = _factory.CreateClient();
            var jsonSerializeOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                  
            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Players.GetAll);
            var deserializedResponse = await JsonSerializer.DeserializeAsync<List<PlayerResponseDto>>(await response.Content.ReadAsStreamAsync(), jsonSerializeOptions);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            deserializedResponse.Count.Should().Be(3);           
        }

        [Fact]
        public async Task Get_ReturnsPost_WhenPostExistInTheDataBase()
        {
            // Arrange
            TestClient = _factory.CreateClient();
            var jsonSerializeOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            CreatePlayerRequestDto createPlayer = new CreatePlayerRequestDto() { FirstName = "Larry", LastName = "Homes", Age = 51, YearOfBirth = 1973, Mounth = 12, Day = 15, Alias = "BullDoozer"! };
            StringContent content = new StringContent(JsonSerializer.Serialize(createPlayer), Encoding.UTF8, "application/json");

            // Act
            var response = await TestClient.PostAsync(ApiRoutes.Players.Create, content);            

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var deserializedResponse = await JsonSerializer.DeserializeAsync<CreatePlayerResponseDto>(await response.Content.ReadAsStreamAsync(), jsonSerializeOptions);
            deserializedResponse.Id.Should().NotBeEmpty();

            // Act
            var responseAfterSuccesfullCreate = await TestClient.GetAsync(ApiRoutes.Players.GetAll);

            // Assert
            responseAfterSuccesfullCreate.StatusCode.Should().Be(HttpStatusCode.OK);
            var deserializedResponseAfterSuccessfullCreate = await JsonSerializer.DeserializeAsync<List<PlayerResponseDto>>(await responseAfterSuccesfullCreate.Content.ReadAsStreamAsync(), jsonSerializeOptions);
            deserializedResponseAfterSuccessfullCreate.Count.Should().Be(4);
        }

        protected async Task<PlayerResponseDto> CreatePostAsync(CreatePlayerRequestDto request)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await TestClient.PostAsync(ApiRoutes.Players.Create, content);
            return null;
        }
    }
}
