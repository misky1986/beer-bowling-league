using BeerBowlingLeague.Server.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Server.Repository
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetTeamsAsync();
        Task<Team> GetTeamByIdAsync(Guid id);
    }
}
