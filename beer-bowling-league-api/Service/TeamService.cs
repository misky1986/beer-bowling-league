using beer_bowling_league_api.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Service
{
    public class TeamService : ITeamService
    {
        public async Task<IEnumerable<TeamResponseDto>> GetTeamsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TeamResponseDto> GetTeamsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
