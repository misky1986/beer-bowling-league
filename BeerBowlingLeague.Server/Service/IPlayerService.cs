using BeerBowlingLeague.Server.Contracts.Requests;
using BeerBowlingLeague.Server.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Server.Service
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerResponseDto>> GetPlayersAsync();
        Task<PlayerResponseDto> GetPlayerByIdAsync(Guid id);
        Task<CreatePlayerResponseDto> CreatePlayerAsync(CreatePlayerRequestDto player);

        Task<bool> UpdatePostAsync(CreatePlayerRequestDto playertoUpdate);

        Task<bool> DeletePostAsync(Guid postId);
    }
}
