using beer_bowling_league_api.Contracts;
using beer_bowling_league_api.Contracts.Responses;
using beer_bowling_league_api.tests.Helpers;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace beer_bowling_league_api.tests.IntegrationTest.Controller
{
    public class TeamControllerIntegrationTests : IntegrationTestSetup
    {
        public TeamControllerIntegrationTests()
        {

        }

        [Fact]        
        public async Task GetAll_WithoutAnyPosts_ReturnsEmptyResponse()
        {
            // Arrange
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
