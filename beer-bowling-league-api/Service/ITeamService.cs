using beer_bowling_league_api.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Service
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamResponseDto>> GetTeamsAsync();
        Task<TeamResponseDto> GetTeamsByIdAsync(Guid id);
    }
}
