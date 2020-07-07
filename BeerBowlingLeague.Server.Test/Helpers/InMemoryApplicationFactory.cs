using BeerBowlingLeague.Server.DataAccess;
using BeerBowlingLeague.Server.Tests.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Writers;
using System;

namespace BeerBowlingLeague.Server.Tests.Helpers
{
    public class InMemoryApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseEnvironment("Testing")
                .ConfigureTestServices(services =>
                {
                    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
                    
                    services.AddScoped<ApplicationDbContext>(serviceProvider =>
                    new TestApplicationDbContext(options));
                    var sp = services.BuildServiceProvider();
                    
                    using var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ApplicationDbContext>();                    
                });
        }

        public void asdasd()
        {

        }

    }
}
