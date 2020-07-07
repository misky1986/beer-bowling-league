using AutoMapper;
using BeerBowlingLeague.Server.Contracts;
using BeerBowlingLeague.Server.Contracts.Requests;
using BeerBowlingLeague.Server.Contracts.Responses;
using BeerBowlingLeague.Server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Server.Controllers
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
        public async Task<IActionResult> Create([FromBody] CreatePlayerRequestDto playerRequestDto)
        {                      
            var createdPlayer = await _playerService.CreatePlayerAsync(playerRequestDto);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Players.Get.Replace("{playerId}", createdPlayer.ToString());
            
            return Created(locationUri, createdPlayer);
        }
    }
}