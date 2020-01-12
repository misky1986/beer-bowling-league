using System.ComponentModel.DataAnnotations;

namespace beer_bowling_league_client.Models
{
    public class PlayerModel1
    {
   
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
        public int Age { get; set; }

    }
}
