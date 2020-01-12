using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Contracts.Responses
{
    public class PlayerResponseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Alias { get; set; }
    }
}
