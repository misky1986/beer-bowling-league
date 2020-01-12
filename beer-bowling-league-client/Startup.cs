using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace beer_bowling_league_client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
