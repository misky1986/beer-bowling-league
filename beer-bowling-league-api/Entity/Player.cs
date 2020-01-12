using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
