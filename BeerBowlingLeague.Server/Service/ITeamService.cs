using BeerBowlingLeague.Server.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Server.Service
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamResponseDto>> GetTeamsAsync();
        Task<TeamResponseDto> GetTeamsByIdAsync(Guid id);
    }
}
