using System.Data;
using System.Text;
using Dapper;
using Newtonsoft.Json;
using PokeApi.Application.DTO;
using PokeApi.Application.Interfaces;
using PokeApi.Infrastructure.Factory;
using PokeApi.Infrastructure.Queries.Output;

namespace PokeApi.Infrastructure.Repositories
{
    public class PokeRepository : IPokeRepository
    {
        private readonly IPokeService _pokeService;
        public readonly IDbConnection _connection;

        public PokeRepository(IPokeService pokeService, SQLiteFactory factory)
        {
            _pokeService = pokeService;
            _connection = factory.SQLiteConnection();
        }

        public async Task<List<PokeAnalyticsDTO>> Get10PokesRange()
        {
            var jsonCompleto = _pokeService.GetAllPokes();

            var json = JsonConvert.DeserializeObject<PokeBaseDTO>(await jsonCompleto);

            Random random = new Random();
            List<PokeAnalyticsDTO> pokes = new List<PokeAnalyticsDTO>();
            List<int> randomList = new List<int>(10);

            for(int i = 0; i < 10; i++)
            {
                int value = random.Next(1281);

                // Consumindo a Api de detalhamento do Pokémon sorteado.
                var returnDetailsPoke = _pokeService.ConsumePokeApi(json.Results[value].Url);
                var jsonEspecific = JsonConvert.DeserializeObject<PokeDetailDTO>(await returnDetailsPoke);
                
                PokeAnalyticsDTO poke = new PokeAnalyticsDTO();

                poke.Name = jsonEspecific.Forms[0].Name;
                poke.Experience = jsonEspecific.Base_Experience;
                string pngString = jsonEspecific.Sprites.Back_Default;
                if(pngString != null && pngString != "")
                {
                    var textBytes = Encoding.UTF8.GetBytes(pngString);
                    var encondingPng = Convert.ToBase64String(textBytes);
                    poke.SpriteDefault = encondingPng;
                }

                // Consumindo a API que nos fornece o endereço da API que nos fornece as evoluções do Pokémon
                var returnSpeciesPoke = _pokeService.ConsumePokeApi(jsonEspecific.Species.Url);
                var jsonSpeciesPoke = JsonConvert.DeserializeObject<PokeSpeciesDTO>(await returnSpeciesPoke);

                // Consumindo a API que nos fornece as evoluções do Pokémon
                var returnEvolutionsPoke = _pokeService.ConsumePokeApi(jsonSpeciesPoke.Evolution_Chain.Url);
                var jsonEvolutionsPoke = JsonConvert.DeserializeObject<PokeEvolutionsDTO>(await returnEvolutionsPoke);

                List<string> evolutions = new List<string>();

                // Verifica se a API retorna alguma evolução para o Pokémon pois, em alguns casos, a API não retorna as evoluções.
                if(jsonEvolutionsPoke.Chain.Evolves_To.Count > 0)
                {
                    evolutions.Add(jsonEvolutionsPoke.Chain.Species.Name);
                    evolutions.Add(jsonEvolutionsPoke.Chain.Evolves_To[0].Species.Name);
                    if(jsonEvolutionsPoke.Chain.Evolves_To[0].Evolves_To.Count > 0)
                    {
                        evolutions.Add(jsonEvolutionsPoke.Chain.Evolves_To[0].Evolves_To[0].Species.Name);
                    }
                }
                else 
                {
                    evolutions.Add("Não há evoluções disponíveis para esse Pokémon.");
                }

                poke.Evolutions = evolutions;

                pokes.Add(poke);
            }

            return  pokes;
        }

        public async Task<PokeAnalyticsDTO> GetPokemon(string pokemon)
        {
            // Consumindo a Api de detalhamento do Pokémon sorteado.
            var returnDetailsPoke = _pokeService.ConsumePokeApi("https://pokeapi.co/api/v2/pokemon/" + pokemon.ToLower());
            var jsonEspecific = JsonConvert.DeserializeObject<PokeDetailDTO>(await returnDetailsPoke);
            
            PokeAnalyticsDTO poke = new PokeAnalyticsDTO();

            poke.Name = jsonEspecific.Forms[0].Name;
            poke.Experience = jsonEspecific.Base_Experience;
            string pngString = jsonEspecific.Sprites.Back_Default;
            if(pngString != null && pngString != "")
            {
                var textBytes = Encoding.UTF8.GetBytes(pngString);
                var encondingPng = Convert.ToBase64String(textBytes);
                poke.SpriteDefault = encondingPng;
            }

            // Consumindo a API que nos fornece o endereço da API que nos fornece as evoluções do Pokémon
            var returnSpeciesPoke = _pokeService.ConsumePokeApi(jsonEspecific.Species.Url);
            var jsonSpeciesPoke = JsonConvert.DeserializeObject<PokeSpeciesDTO>(await returnSpeciesPoke);

            // Consumindo a API que nos fornece as evoluções do Pokémon
            var returnEvolutionsPoke = _pokeService.ConsumePokeApi(jsonSpeciesPoke.Evolution_Chain.Url);
            var jsonEvolutionsPoke = JsonConvert.DeserializeObject<PokeEvolutionsDTO>(await returnEvolutionsPoke);

            List<string> evolutions = new List<string>();

            if(jsonEvolutionsPoke.Chain.Evolves_To.Count > 0)
            {
                evolutions.Add(jsonEvolutionsPoke.Chain.Species.Name);
                evolutions.Add(jsonEvolutionsPoke.Chain.Evolves_To[0].Species.Name);
                if(jsonEvolutionsPoke.Chain.Evolves_To[0].Evolves_To.Count > 0)
                {
                    evolutions.Add(jsonEvolutionsPoke.Chain.Evolves_To[0].Evolves_To[0].Species.Name);
                }
            }
            else 
            {
                evolutions.Add("Não há evoluções disponíveis para esse Pokémon.");
            }

            poke.Evolutions = evolutions;

            return poke;
        }

        public IEnumerable<PokesCapturadosDTO> GetPokemonsCapturados()
        {
            var query = new PokeQueriesOutput().GetPokemonsCapturados();

            try
            {
                using(_connection)
                {
                    return _connection.Query<PokesCapturadosDTO>(query.Query) as List<PokesCapturadosDTO>;
                }
            }
            catch 
            {
                throw new Exception("Falha ao retornar Pokemons capturados.");
            }
        }
    }
}