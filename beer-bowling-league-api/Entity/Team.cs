using System;
using System.ComponentModel.DataAnnotations;

namespace beer_bowling_league_api.Entity
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
