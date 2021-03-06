﻿using BeerBowlingLeague.Server.DataAccess;
using BeerBowlingLeague.Server.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Server.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TeamRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Team> GetTeamByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return await _dbContext.Teams?.ToListAsync();
        }
    }
}
