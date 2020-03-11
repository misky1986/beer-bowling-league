using AutoMapper;
using beer_bowling_league_api.Contracts.Responses;
using beer_bowling_league_api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Service
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
