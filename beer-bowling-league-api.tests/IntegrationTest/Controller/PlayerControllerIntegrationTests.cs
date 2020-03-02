using beer_bowling_league_api.Contracts;
using beer_bowling_league_api.tests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace beer_bowling_league_api.tests.IntegrationTest.Controller
{
    public class PlayerControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<beer_bowling_league_api.Startup>>
    {

        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;
        public PlayerControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task GetAll_WithoutAnyPosts_ReturnsEmptyResponse()
        {
            // Arrange
                  
            // Act
            var response = await _client.GetAsync(ApiRoutes.Players.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);            
        }

        [Fact]
        public async Task Get_ReturnsPost_WhenPostExistInTheDataBase()
        {
            // Arrange
            //await AuthenticateAsync();
            //var createdPost = await CreatePostAsync(new CreatePostRequest { Name = "Test post" });

            //// Act
            //var response = await TestClient.GetAsync(ApiRoutes.Posts.Get.Replace("{postId}", createdPost.Id.ToString()));

            //// Assert
            //response.StatusCode.Should().Be(HttpStatusCode.OK);
            //var returnedPost = await response.Content.ReadAsAsync<Post>();
            //returnedPost.Id.Should().Be(createdPost.Id);
            //returnedPost.Name.Should().Be("Test post");
        }
    }
}
