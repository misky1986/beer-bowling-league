using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeerBowlingLeague.Server.Contracts;
using BeerBowlingLeague.Server.Contracts.Responses;
using BeerBowlingLeague.Server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerBowlingLeague.Server.Controllers
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