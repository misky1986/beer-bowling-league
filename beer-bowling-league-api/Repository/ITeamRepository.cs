using beer_bowling_league_api.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Repository
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetTeamsAsync();
        Task<Team> GetTeamByIdAsync(Guid id);
    }
}
