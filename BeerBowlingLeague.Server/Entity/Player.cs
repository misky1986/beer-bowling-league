using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace BeerBowlingLeague.Server.Entity
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
        [DataType(DataType.Date)]
        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime BirthDay { get; set; }        
    }
}
