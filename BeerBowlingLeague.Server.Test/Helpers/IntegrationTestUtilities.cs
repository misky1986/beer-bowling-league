﻿using BeerBowlingLeague.Server.DataAccess;
using BeerBowlingLeague.Server.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BeerBowlingLeague.Server.Tests.Helpers
{
    public class IntegrationTestUtilities
    {
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Players.AddRange(GetSeedingPlayers());

            db.Teams.AddRange(GetSeedingTeams());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApplicationDbContext db)
        {
            db.Players.RemoveRange(db.Players);
            db.Teams.RemoveRange(db.Teams);
            InitializeDbForTests(db);
        }
        
        public static List<Player> GetSeedingPlayers()
        {
            return new List<Player>()
            {
                new Player() { Age = 50, BirthDay =  new DateTime(1970, 9, 25), Alias = "Sucker", FirstName = "Dave", LastName = "Johnson" },
                new Player() { Age = 33, BirthDay =  new DateTime(1987, 2, 6), Alias = "Mambo", FirstName = "Jordan", LastName = "Cramp" },
                new Player() { Age = 100, BirthDay =  new DateTime(1920, 2, 6), Alias = "OldyJohn", FirstName = "John", LastName = "Doe" },
            };
        }

        public static List<Team> GetSeedingTeams()
        {
            return new List<Team>()
            {
                new Team() { Id = Guid.NewGuid(), Name = "Sucker1" },
                new Team() { Id = Guid.NewGuid(), Name = "Sucker2" },
                new Team() { Id = Guid.NewGuid(), Name = "Sucker3" },
                new Team() { Id = Guid.NewGuid(), Name = "Sucker4" }
            };
        }

        public static void EnsureDatabaseCreated(InMemoryApplicationFactory<Startup> factory)
        {
            ApplicationDbContext applicationDbContext = factory.Services.GetRequiredService<ApplicationDbContext>();
            applicationDbContext.Database.EnsureCreated();
        }

        public static void EnsureDatabaseDeleted(InMemoryApplicationFactory<Startup> factory)
        {
            ApplicationDbContext applicationDbContext = factory.Services.GetRequiredService<ApplicationDbContext>();
            applicationDbContext.Database.EnsureDeleted();
        }
    }
}
