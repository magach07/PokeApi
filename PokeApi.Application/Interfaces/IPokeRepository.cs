using PokeApi.Application.DTO;

namespace PokeApi.Application.Interfaces
{
    public interface IPokeRepository
    {
        Task<List<PokeAnalyticsDTO>> Get10PokesRange();
        Task<PokeAnalyticsDTO> GetPokemon(string pokemon);
        IEnumerable<PokesCapturadosDTO> GetPokemonsCapturados();
    }
}