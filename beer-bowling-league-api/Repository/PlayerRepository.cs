using beer_bowling_league_api.DataAccess;
using beer_bowling_league_api.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Repository
{

    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PlayerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            return await _dbContext.Players?.ToListAsync();
        }

        public Task<Player> GetPlayerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreatePlayerAsync(Player player)
        {
            await _dbContext.Players.AddAsync(player);

            var playerCreated = await _dbContext.SaveChangesAsync();

            return playerCreated > 0;
        }

        public Task<bool> DeletePostAsync(Guid postId)
        {
            throw new NotImplementedException();
        }      

        public Task<bool> UpdatePostAsync(Player playertoUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
