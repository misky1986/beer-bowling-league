﻿using BeerBowlingLeague.Server.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Server.Repository
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetPlayersAsync();
        Task<Player> GetPlayerByIdAsync(Guid id);
        Task<Player> CreatePlayerAsync(Player player);

        Task<bool> UpdatePostAsync(Player playertoUpdate);

        Task<bool> DeletePostAsync(Guid postId);
    }
}
