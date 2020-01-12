using beer_bowling_league_api.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Service
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayersAsync();
        Task<Player> GetPlayerByIdAsync(Guid id);
        Task<bool> CreatePlayerAsync(Player player);

        Task<bool> UpdatePostAsync(Player playertoUpdate);

        Task<bool> DeletePostAsync(Guid postId);
    }
}
