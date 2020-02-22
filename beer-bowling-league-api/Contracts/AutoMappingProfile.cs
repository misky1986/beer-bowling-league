using AutoMapper;
using beer_bowling_league_api.Contracts.Requests;
using beer_bowling_league_api.Contracts.Responses;
using beer_bowling_league_api.Entity;
using System;

namespace beer_bowling_league_api.Contracts
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Player, PlayerResponseDto>();

            CreateMap<PlayerRequestDto, Player>()
                .ForMember(dest => dest.BirthDay, 
                opt => opt.MapFrom(src => new DateTime(src.YearOfBirth, src.Mounth, src.Day)));
        }
    }
}
