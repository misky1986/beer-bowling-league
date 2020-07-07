using AutoMapper;
using BeerBowlingLeague.Server.Contracts.Responses;
using BeerBowlingLeague.Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Server.Service
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamResponseDto>> GetTeamsAsync()
        {
            var teams = await _teamRepository.GetTeamsAsync();

            return teams.Select(team => _mapper.Map<TeamResponseDto>(team));
        }

        public async Task<TeamResponseDto> GetTeamsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
