using BeerBowlingLeague.Server.DataAccess;
using BeerBowlingLeague.Server.Entity;
using Microsoft.EntityFrameworkCore;

namespace BeerBowlingLeague.Server.Tests.Infrastructure
{
    public class TestApplicationDbContext : ApplicationDbContext
    {
        public TestApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            modelBuilder.Seed<Player>("Testdata/player.json");
            modelBuilder.Seed<Team>("Testdata/team.json");
        }
    }
}
