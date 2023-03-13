using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokeApi.Application.DTO
{
    public class PokeBaseDTO
    {
        [JsonPropertyName("count")]
        public long Count { get; set; }

        [JsonPropertyName("next")]
        public object Next { get; set; }

        [JsonPropertyName("previous")]
        public object Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}