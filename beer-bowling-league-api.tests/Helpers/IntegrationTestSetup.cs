using beer_bowling_league_api.DataAccess;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;

namespace beer_bowling_league_api.tests.Helpers
{
    public class IntegrationTestSetup : IDisposable
    {
        protected readonly HttpClient TestClient;
        private readonly IServiceProvider _serviceProvider;

        protected IntegrationTestSetup()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                        if (descriptor != null)
                        {
                            services.Remove(descriptor);
                        }


                        // Add ApplicationDbContext using an in-memory database for testing.
                        services.AddDbContext<ApplicationDbContext>(options => { options.UseInMemoryDatabase("InMemoryDbForTesting"); });

                        // Build the service provider.
                        var serviceProvider = services.BuildServiceProvider();

                        // Create a scope to obtain a reference to the database context (ApplicationDbContext).
                        using (var scope = serviceProvider.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                            var logger = scopedServices.GetRequiredService<ILogger<Startup>>();

                            // Ensure the database is created.
                            db.Database.EnsureCreated();

                            try
                            {
                                // Seed the database with test data.
                                IntegrationTestUtilities.InitializeDbForTests(db);
                            }
                            catch (Exception ex)
                            {
                                logger.LogError(ex, "An error occurred seeding the " +
                                    "database with test messages. Error: {Message}", ex.Message);
                            }
                        }
                    });


                });
            _serviceProvider = appFactory.Services;
            TestClient = appFactory.CreateClient();
        }

        public void Dispose()
        {
            using var serviceScope = _serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureDeleted();
        }
    }
}
