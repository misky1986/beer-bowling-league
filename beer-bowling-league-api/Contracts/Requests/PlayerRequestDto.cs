using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beer_bowling_league_api.Contracts.Requests
{
    public class PlayerRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Alias { get; set; }
        public int YearOfBirth { get; set; }
        public int Mounth { get; set; }
        public int Day { get; set; }
    }
}
