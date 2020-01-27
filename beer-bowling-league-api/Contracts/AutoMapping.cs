using AutoMapper;
using beer_bowling_league_api.Contracts.Responses;
using beer_bowling_league_api.Entity;

namespace beer_bowling_league_api.Contracts
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Player, PlayerResponseDto>();
        }
    }
}
