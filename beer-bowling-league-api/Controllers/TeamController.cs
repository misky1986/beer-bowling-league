using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using beer_bowling_league_api.Contracts;
using beer_bowling_league_api.Contracts.Responses;
using beer_bowling_league_api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace beer_bowling_league_api.Controllers
{    
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamController(IMapper mapper, ITeamService teamService)
        {
            _mapper = mapper;
            _teamService = teamService;
        }

        [HttpGet(ApiRoutes.Teams.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamService.GetTeamsAsync();

            if(teams == null || !teams.Any())
            {
                return NotFound();
            }

            var teamResponse = teams.Select(team => _mapper.Map<TeamResponseDto>(team));

            return Ok(teamResponse);
        }
    }
}