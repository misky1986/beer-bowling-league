using beer_bowling_league_api.DataAccess;
using beer_bowling_league_api.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _dbContext;

        public PlayerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public Task<Player> GetPlayerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            return await _dbContext.Players?.ToListAsync();
        }

        public Task<bool> UpdatePostAsync(Player playertoUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
