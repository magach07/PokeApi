using System.Text.Json.Serialization;

namespace PokeApi.Application.DTO
{
    public class PokeEvolutionsDTO
    {
        [JsonPropertyName("baby_trigger_item")]
        public object BabyTriggerItem { get; set; }

        [JsonPropertyName("chain")]
        public Chain Chain { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }
    }

    public class Chain
    {
        [JsonPropertyName("evolution_details")]
        public List<EvolutionDetail> EvolutionDetails { get; set; }

        [JsonPropertyName("evolves_to")]
        public List<Chain> Evolves_To { get; set; }

        [JsonPropertyName("is_baby")]
        public bool IsBaby { get; set; }

        [JsonPropertyName("species")]
        public Species Species { get; set; }
    }

    public class EvolutionDetail
    {
        [JsonPropertyName("gender")]
        public object Gender { get; set; }

        [JsonPropertyName("held_item")]
        public object HeldItem { get; set; }

        [JsonPropertyName("item")]
        public Species Item { get; set; }

        [JsonPropertyName("known_move")]
        public object KnownMove { get; set; }

        [JsonPropertyName("known_move_type")]
        public object KnownMoveType { get; set; }

        [JsonPropertyName("location")]
        public object Location { get; set; }

        [JsonPropertyName("min_affection")]
        public object MinAffection { get; set; }

        [JsonPropertyName("min_beauty")]
        public object MinBeauty { get; set; }

        [JsonPropertyName("min_happiness")]
        public long? MinHappiness { get; set; }

        [JsonPropertyName("min_level")]
        public object MinLevel { get; set; }

        [JsonPropertyName("needs_overworld_rain")]
        public bool NeedsOverworldRain { get; set; }

        [JsonPropertyName("party_species")]
        public object PartySpecies { get; set; }

        [JsonPropertyName("party_type")]
        public object PartyType { get; set; }

        [JsonPropertyName("relative_physical_stats")]
        public object RelativePhysicalStats { get; set; }

        [JsonPropertyName("time_of_day")]
        public string TimeOfDay { get; set; }

        [JsonPropertyName("trade_species")]
        public object TradeSpecies { get; set; }

        [JsonPropertyName("trigger")]
        public Species Trigger { get; set; }

        [JsonPropertyName("turn_upside_down")]
        public bool TurnUpsideDown { get; set; }
    }

    public class Species
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}