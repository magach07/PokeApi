using PokeApi.Domain.Entities;

namespace PokeApi.Application.Interfaces
{
    public interface IInsertRepository
    {
        void InsertMestrePokemon(MestrePokemonEntity mestre);
        void InsertPokemonCapturado (PokemonCapturadoEntity capturado);
    }
}