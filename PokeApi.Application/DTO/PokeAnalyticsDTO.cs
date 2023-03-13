namespace PokeApi.Application.DTO
{
    public class PokeAnalyticsDTO
    {
        public string? Name { get; set; }
        public int? Experience { get; set; }
        public List<string>? Evolutions { get; set; }
        public string? SpriteDefault { get; set; }
    }
}