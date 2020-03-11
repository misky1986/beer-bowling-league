using System;
using System.ComponentModel.DataAnnotations;

namespace beer_bowling_league_api.Entity
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Alias { get; set; }
        public DateTime BirthDay { get; set; }        
    }
}
