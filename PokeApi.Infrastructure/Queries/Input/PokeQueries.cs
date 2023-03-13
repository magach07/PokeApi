using PokeApi.Domain.Entities;
using PokeApi.Infrastructure.Mapping;

namespace PokeApi.Infrastructure.Queries.Input
{
    public class PokeQueries : BaseQuery
    {
        public QueryModel InsertMestreQuery(MestrePokemonEntity mestre)
        {
            this.Table = Map.GetMestrePokemonTable();
            this.Query = $@"
                INSERT INTO {this.Table} ([CL_NAME], [CL_IDADE], [CL_CPF]) VALUES(@Name, @Idade, @Cpf)";

            this.Parameters = new
            {
                Name = mestre.Name,
                Idade = mestre.Idade,
                Cpf = mestre.Cpf
            };

            return new QueryModel(this.Query, this.Parameters);
        }

        public QueryModel InsertPokemonCapturado(PokemonCapturadoEntity capturado)
        {
            this.Table = Map.GetPokemonCapturado();
            this.Query = $@"INSERT INTO {this.Table} ([CL_NAME], [CL_DATA_CAPTURA], [CL_ID_TREINADOR]) VALUES (@Name, @Data_Captura, @Id_Treinador)";

            this.Parameters = new
            {
                Name = capturado.Name,
                Data_Captura = capturado.Data_Captura,
                Id_Treinador = capturado.Id_Treinador
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}