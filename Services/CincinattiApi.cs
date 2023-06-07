using System.Text.Json;
using Newtonsoft.Json.Linq;
using RedsMVC_API.Models;

namespace RedsMVC_API.Services
{
    public class CincinattiApi
    {
        public async Task<Root> GetPlayers(string query)
        {
            string apikey = File.ReadAllText("appsettings.json");
            var key = JObject.Parse(apikey).GetValue("DefaultKey").ToString();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://mlb-data.p.rapidapi.com/json/named.roster_40.bam?team_id='113'"),
                Headers =
                {
                    { "X-RapidAPI-Key", key },
                    { "X-RapidAPI-Host", "mlb-data.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the response JSON into objects
                var root = JsonSerializer.Deserialize<Root>(responseBody);

                 Console.WriteLine("Here are your Cincinnati Reds!!!");

                // write names and positions of players
                foreach (var player in root.roster_40.queryResults.row)
                {
                    Console.WriteLine($"Name: {player.name_use} {player.name_last} Position:{player.position_txt} ");
                }


                //filter liste by query

                return root;
            }
                         
        }
    }
}
