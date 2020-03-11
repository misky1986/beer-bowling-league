using beer_bowling_league_api.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Repository
{
    public class TeamRepository : ITeamRepository
    {
        public Task<Team> GetTeamByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Team>> GetTeamsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
