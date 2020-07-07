using System;
using System.ComponentModel.DataAnnotations;

namespace BeerBowlingLeague.Server.Entity
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
