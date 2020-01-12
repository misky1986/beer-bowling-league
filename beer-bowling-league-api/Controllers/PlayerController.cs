using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beer_bowling_league_api.Contracts;
using beer_bowling_league_api.Contracts.Requests;
using beer_bowling_league_api.Contracts.Responses;
using beer_bowling_league_api.Entity;
using beer_bowling_league_api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace beer_bowling_league_api.Controllers
{
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet(ApiRoutes.Players.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerService.GetPlayersAsync();
            var playerResponse = players.Select(player => new PlayerResponseDto
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                Age = player.Age,
                Alias = player.Alias
            });

            return Ok(playerResponse);
        }

        [HttpPost(ApiRoutes.Players.Create)]
        public async Task<IActionResult> Create([FromBody] PlayerRequestDto playerRequest)
        {
            var playerId = Guid.NewGuid();

            var player = new Player
            {
                Id = playerId,
                FirstName = playerRequest.FirstName,
                LastName = playerRequest.LastName,
                Age = playerRequest.Age,
                Alias = playerRequest.Alias
            };

            await _playerService.CreatePlayerAsync(player);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Players.Get.Replace("{playerId}", player.Id.ToString());

            var response = new PlayerResponseDto
            {            
                FirstName = player.FirstName,
                LastName = player.LastName,
                Age = player.Age,
                Alias = player.Alias                
            };

            return Created(locationUri, response);
        }
    }
}