using beer_bowling_league_api.DataAccess;
using beer_bowling_league_api.Entity;
using System;
using System.Collections.Generic;

namespace beer_bowling_league_api.tests.Helpers
{
    public class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            db.Players.AddRange(GetSeedingMessages());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApplicationDbContext db)
        {
            db.Players.RemoveRange(db.Players);
            InitializeDbForTests(db);
        }
        
        public static List<Player> GetSeedingMessages()
        {
            return new List<Player>()
            {
                new Player() { Age = 50, BirthDay =  new DateTime(1970, 9, 25), Alias = "Sucker", FirstName = "Dave", LastName = "Johnson" },
                new Player() { Age = 33, BirthDay =  new DateTime(1987, 2, 6), Alias = "Mambo", FirstName = "Jordan", LastName = "Cramp" },
                new Player() { Age = 100, BirthDay =  new DateTime(1920, 2, 6), Alias = "OldyJohn", FirstName = "John", LastName = "Doe" },
            };
        }
    }
}
