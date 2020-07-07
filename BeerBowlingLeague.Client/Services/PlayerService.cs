using BeerBowlingLeague.Client.Pages;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BeerBowlingLeague.Client.Services
{
    public class PlayerService
    {
        private readonly HttpClient _httpClient;

        public PlayerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Player>> GetPlayerAsync()
        {
            List<Player> players = new List<Player>();
            
            try
            {
                players = await _httpClient.GetFromJsonAsync<List<Player>>("https://localhost:44388/api/v1/players");                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error occoured: ", ex);
                Console.WriteLine("Exception Message: ", ex.Message);
            }
            return players;
        }
        public async Task PostPlayerAsync(Player player)
        {
            //await _httpClient.PostJsonAsync("https://localhost:44388/api/v1/players", player);
        }
    }
}
