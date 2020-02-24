using beer_bowling_league_api.Contracts.Requests;
using beer_bowling_league_api.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Service
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerResponseDto>> GetPlayersAsync();
        Task<PlayerResponseDto> GetPlayerByIdAsync(Guid id);
        Task<PlayerCreatedResponseDto> CreatePlayerAsync(PlayerRequestDto player);

        Task<bool> UpdatePostAsync(PlayerRequestDto playertoUpdate);

        Task<bool> DeletePostAsync(Guid postId);
    }
}
