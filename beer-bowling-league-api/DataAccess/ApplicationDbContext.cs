using beer_bowling_league_api.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace beer_bowling_league_api.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }

    }
}
