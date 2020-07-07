using BeerBowlingLeague.Server.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Server.Tests.Helpers
{
    public class UnitTestUtilities
    {
        protected async Task<IEnumerable<PlayerResponseDto>> GetPlayersMockedAsync()
        {
            List<PlayerResponseDto> playerList = new List<PlayerResponseDto>();

            for (int i = 1; i < 4; i++)
            {
                var player = new PlayerResponseDto()

                {
                    Age = i,
                    FirstName = "John" + i,
                    LastName = "Doe" + i,
                    Alias = "Dooezer" + i
                };
                playerList.Add(player);
            }

            return await Task.FromResult(playerList);
        }

        protected Task<IEnumerable<PlayerResponseDto>> GetEmptyPlayerListsAsync()
        {
            IEnumerable<PlayerResponseDto> playerList = new List<PlayerResponseDto>();

            return Task.FromResult(playerList);
        }

        protected async Task<IEnumerable<TeamResponseDto>> GetTeamsMockedAsync()
        {
            List<TeamResponseDto> teamList = new List<TeamResponseDto>();

            for (int i = 1; i < 5; i++)
            {
                var team = new TeamResponseDto()

                {                    
                    Id = Guid.NewGuid(),
                    Name = "Sweat" + i,                    
                };
                teamList.Add(team);
            }

            return await Task.FromResult(teamList);
        }

        protected Task<IEnumerable<TeamResponseDto>> GetEmptyTeamListsAsync()
        {
            IEnumerable<TeamResponseDto> teamList = new List<TeamResponseDto>();

            return Task.FromResult(teamList);
        }
    }
}
