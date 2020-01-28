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

            // Before AutoMapper
            //var playerResponse = players.Select(player => new PlayerResponseDto
            //{
            //    FirstName = player.FirstName,
            //    LastName = player.LastName,
            //    Age = player.Age,
            //    Alias = player.Alias
            //});

            var playerResponse = players.Select(player => _mapper.Map<PlayerResponseDto>(player));

            return Ok(playerResponse);
        }

        [HttpPost(ApiRoutes.Players.Create)]
        public async Task<IActionResult> Create([FromBody] PlayerRequestDto playerRequestDto)
        {
            var playerId = Guid.NewGuid();

            //var player = new Player
            //{
            //    Id = playerId,
            //    FirstName = playerRequestDto.FirstName,
            //    LastName = playerRequestDto.LastName,
            //    Age = playerRequestDto.Age,
            //    Alias = playerRequestDto.Alias                
            //};

            var playerEntity = _mapper.Map<Player>(playerRequestDto);

            await _playerService.CreatePlayerAsync(playerEntity);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Players.Get.Replace("{playerId}", playerEntity.Id.ToString());

            // Before AutoMapper
            //var response = new PlayerResponseDto
            //{            
            //    FirstName = player.FirstName,
            //    LastName = player.LastName,
            //    Age = player.Age,
            //    Alias = player.Alias                
            //};

            var response = _mapper.Map<PlayerResponseDto>(playerEntity);

            return Created(locationUri, response);
        }
    }
}