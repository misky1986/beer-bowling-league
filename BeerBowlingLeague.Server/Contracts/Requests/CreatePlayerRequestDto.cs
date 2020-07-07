namespace BeerBowlingLeague.Server.Contracts.Requests
{
    public class CreatePlayerRequestDto
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
