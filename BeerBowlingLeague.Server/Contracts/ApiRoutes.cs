namespace BeerBowlingLeague.Server.Contracts
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Players
        {
            public const string Create = Base + "/players";
            public const string Get = Base + "/players/{playerId}";
            public const string GetAll = Base + "/players";
            public const string Update = Base + "/players/{playerId}";
            public const string Delete = Base + "/players/{playerId}";
        }

        public static class Teams
        {
            public const string Create = Base + "/teams";
            public const string Get = Base + "/teams/{teamId}";
            public const string GetAll = Base + "/teams";
            public const string Update = Base + "/teams/{teamId}";
            public const string Delete = Base + "/teams/{teamId}";            
        }
    }
}
