using beer_bowling_league_api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Repository
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetPlayersAsync();
        Task<Player> GetPlayerByIdAsync(Guid id);
        Task<bool> CreatePlayerAsync(Player player);

        Task<bool> UpdatePostAsync(Player playertoUpdate);

        Task<bool> DeletePostAsync(Guid postId);
    }
}
