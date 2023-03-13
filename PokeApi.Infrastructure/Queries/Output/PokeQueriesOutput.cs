using PokeApi.Infrastructure.Mapping;

namespace PokeApi.Infrastructure.Queries.Output
{
    public class PokeQueriesOutput : BaseQuery
    {
        public QueryModel GetPokemonsCapturados()
        {
            this.Table = Map.GetPokemonCapturado();
            this.InnerTable = Map.GetMestrePokemonTable();

            this.Query = $@"
                SELECT POK.CL_NAME AS NAME,
                POK.CL_DATA_CAPTURA AS DATA_CAPTURA,
                MES.CL_NAME AS NOME_TREINADOR
                FROM {this.Table} POK
                INNER JOIN {this.InnerTable} MES ON MES.ID = POK.CL_ID_TREINADOR
            ";

            return new QueryModel(this.Query, null);
        }
    }
}