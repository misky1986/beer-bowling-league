using BeerBowlingLeague.Server.DataAccess;
using BeerBowlingLeague.Server.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Server.Repository
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

        public async Task<Player> CreatePlayerAsync(Player player)
        {
            await _dbContext.Players.AddAsync(player);
                       
            await _dbContext.SaveChangesAsync();

            return player;  
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
