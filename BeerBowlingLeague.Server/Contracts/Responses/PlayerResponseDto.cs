using System;

namespace BeerBowlingLeague.Server.Contracts.Responses
{
    public class PlayerResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Alias { get; set; }
    }
}
