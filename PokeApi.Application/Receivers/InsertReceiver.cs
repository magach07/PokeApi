using PokeApi.Application.Commands.PokeAPIContext;
using PokeApi.Application.Interfaces;
using PokeApi.Domain.Entities;

namespace PokeApi.Application.Receivers
{
    public class InsertReceiver
    {
        private readonly IInsertRepository _insertRepository;

        public InsertReceiver(IInsertRepository insertRepository)
        {
            _insertRepository = insertRepository;
        }

        public State ActionMestre (MestrePokemonCommand command)
        {
            var mestre = new MestrePokemonEntity(command.Name, command.Idade, command.Cpf);

            try
            {
                _insertRepository.InsertMestrePokemon(mestre);
                return new State(200, "Mestre Pokemon adicionado com sucesso", mestre);
            }
            catch (Exception e)
            {
                return new State(400, "Falha ao inserir Mestre Pokemon, verifique os campos e tente novamente. " + e.Message, null);
            }
        }

        public State ActionCaptura (PokemonCapturadoCommand command)
        {
            var capturado = new PokemonCapturadoEntity(command.Name, command.Id_Treinador);

            try
            {
                _insertRepository.InsertPokemonCapturado(capturado);
                return new State(200, "Pokemon adicionado com sucesso", capturado);
            }
            catch (Exception e)
            {
                return new State(400, "Falha ao inserir Pokemon, verifique os campos e tente novamente. " + e.Message, null);
            }
        }
    }
}