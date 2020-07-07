using AutoMapper;
using BeerBowlingLeague.Server.Contracts.Requests;
using BeerBowlingLeague.Server.Contracts.Responses;
using BeerBowlingLeague.Server.Entity;
using System;

namespace BeerBowlingLeague.Server.Contracts
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // Request to domain model
            CreateMap<CreatePlayerRequestDto, Player>()
                .ForMember(dest => dest.BirthDay, 
                opt => opt.MapFrom(src => new DateTime(src.YearOfBirth, src.Mounth, src.Day)));

            // Domain model to response dto
            CreateMap<Player, PlayerResponseDto>();
            CreateMap<Player, CreatePlayerResponseDto>();

            CreateMap<Team, TeamResponseDto>();

        }
    }
}
