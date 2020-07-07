using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Client.Pages
{
    public partial class Player : ComponentBase
    {
        [Inject] private HttpClient HttpClient { get; set; }
        public List<Player> players = new List<Player>();
        public Player player = new Player();

        [Required]
        [StringLength(16, ErrorMessage = "First name is too long (16 character limit).")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "First name is too long (32 character limit).")]
        public string LastName { get; set; }

        [Range(15, 150, ErrorMessage = "Age ouf of range from 15 to 150")]
        public int Age { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Alias is requiered and needs to be at least 1 character long")]
        public string Alias { get; set; }

        [Required]
        [Range(1900, 3000, ErrorMessage = "Year of birth out of range from 1900 to 3000")]
        public int YearOfBirth { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Mounth of out of range from 1 to 12")]
        public int Mounth { get; set; }

        [Required]
        [Range(1, 31, ErrorMessage = "Day of out of range from 1 to 31")]
        public int Day { get; set; }

        protected async Task ValidSubmit()
        {
            Console.WriteLine("Valid form input!");
            //await HttpClient.PostJsonAsync("https://localhost:44388/api/v1/players", player);
        }

        protected override async Task OnInitializedAsync()
        {
            //players = await PlayerService.GetPlayerAsync();
            //players = await HttpClient.GetJsonAsync<List<Player>>("https://localhost:44388/api/v1/players");

        }
    }
}
