using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokemon
{
    public class GetPokemon
    {
        private static HttpClient HttpClient
            = new HttpClient() { BaseAddress = new Uri("https://pokeapi.co/api/v2/") };

        public static async Task<List<Pokemon>> Get()
        {
            var pokemonResponse = await HttpClient.GetAsync("pokemon");
            pokemonResponse.EnsureSuccessStatusCode();
            var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
            var pokemons = JsonSerializer.Deserialize<Pokemons>(responseBody);
            //pokemons.Results.ForEach(p => Console.WriteLine(p.Name));
            return pokemons.Results;
        }
    }
}
