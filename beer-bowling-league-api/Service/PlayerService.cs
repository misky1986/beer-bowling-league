﻿using AutoMapper;
using beer_bowling_league_api.Contracts.Requests;
using beer_bowling_league_api.Contracts.Responses;
using beer_bowling_league_api.DataAccess;
using beer_bowling_league_api.Entity;
using beer_bowling_league_api.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Service
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

        public async Task<bool> CreatePlayerAsync(PlayerRequestDto player)
        {
            var mappedDomainPlayer = _mapper.Map<Player>(player);

            var response = await _playerRepository.CreatePlayerAsync(mappedDomainPlayer);

            return response;
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

        public Task<bool> UpdatePostAsync(PlayerRequestDto playertoUpdate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(Guid postId)
        {
            throw new NotImplementedException();
        }     
    }
}
