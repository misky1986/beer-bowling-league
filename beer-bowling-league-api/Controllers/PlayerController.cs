using AutoMapper;
using beer_bowling_league_api.Contracts;
using beer_bowling_league_api.Contracts.Requests;
using beer_bowling_league_api.Contracts.Responses;
using beer_bowling_league_api.Entity;
using beer_bowling_league_api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Controllers
{
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerController(IMapper mapper, IPlayerService playerService)
        {
            _mapper = mapper;
            _playerService = playerService;
        }

        [HttpGet(ApiRoutes.Players.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerService.GetPlayersAsync();

            if (players == null || !players.Any())
            {
                return NotFound();
            }

            var playerResponse = players.Select(player => _mapper.Map<PlayerResponseDto>(player));

            return Ok(playerResponse);
        }

        [HttpPost(ApiRoutes.Players.Create)]
        public async Task<IActionResult> Create([FromBody] PlayerRequestDto playerRequestDto)
        {                      
            var createdPlayer = await _playerService.CreatePlayerAsync(playerRequestDto);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Players.Get.Replace("{playerId}", createdPlayer.ToString());
            
            return Created(locationUri, createdPlayer);
        }
    }
}