﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Contracts
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
    }
}
