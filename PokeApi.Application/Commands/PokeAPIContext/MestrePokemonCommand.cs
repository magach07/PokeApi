using PokeApi.Application.Commands.Interfaces;

namespace PokeApi.Application.Commands.PokeAPIContext
{
    public class MestrePokemonCommand : ICommand
    {
        public string? Name { get; set; }
        public int Idade { get; set; }
        public string? Cpf { get; set; }
    }
}