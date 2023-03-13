using System.Data;
using Dapper;
using PokeApi.Application.Interfaces;
using PokeApi.Domain.Entities;
using PokeApi.Infrastructure.Factory;
using PokeApi.Infrastructure.Queries.Input;

namespace PokeApi.Infrastructure.Repositories
{
    public class InsertRepository : IInsertRepository
    {
        private readonly IDbConnection _connection;

        public InsertRepository(SQLiteFactory factory)
        {
            _connection = factory.SQLiteConnection();
        }

        public void InsertMestrePokemon(MestrePokemonEntity entity)
        {
            var query = new PokeQueries().InsertMestreQuery(entity);
            try
            {
                _connection.Open();   
                    _connection.Execute(query.Query, query.Parameters);
                _connection.Close();
            }
            catch
            {
                throw new Exception("Erro ao inserir mestre pokemon");
            }
        }

        public void InsertPokemonCapturado(PokemonCapturadoEntity entity)
        {
            var query = new PokeQueries().InsertPokemonCapturado(entity);
            try
            {
                _connection.Open();   
                    _connection.Execute(query.Query, query.Parameters);
                _connection.Close();
            }
            catch
            {
                throw new Exception("Erro ao inserir pokemon capturado");
            }
        }
    }
}