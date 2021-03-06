﻿using AutoMapper;
using BeerBowlingLeague.Server.Contracts.Requests;
using BeerBowlingLeague.Server.Contracts.Responses;
using BeerBowlingLeague.Server.Entity;
using BeerBowlingLeague.Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Server.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<CreatePlayerResponseDto> CreatePlayerAsync(CreatePlayerRequestDto player)
        {
            var mappedDomainPlayer = _mapper.Map<Player>(player);

            var createdPlayer = await _playerRepository.CreatePlayerAsync(mappedDomainPlayer);

            return _mapper.Map<CreatePlayerResponseDto>(createdPlayer);
        }

        public async Task<IEnumerable<PlayerResponseDto>> GetPlayersAsync()
        {
            var players = await _playerRepository.GetPlayersAsync();

            return players.Select(player => _mapper.Map<PlayerResponseDto>(player));            
        }

        public Task<PlayerResponseDto> GetPlayerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }        

        public Task<bool> UpdatePostAsync(CreatePlayerRequestDto playertoUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(Guid postId)
        {
            throw new NotImplementedException();
        }     
    }
}
