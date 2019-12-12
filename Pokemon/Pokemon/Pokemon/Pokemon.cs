using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Pokemon
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("front_default")]
        public Uri DefaultPicture { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("abilities")]
        public List<String> Abilities { get; set; }

        [JsonPropertyName("back_default")]
        public Uri BackPicture { get; set; }
    }

    public class Pokemons
    {
        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
    }
}
