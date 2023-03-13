using Newtonsoft.Json;
using PokeApi.Application.DTO;
using PokeApi.Application.Interfaces;

namespace PokeApi.Infrastructure.Services
{
    public class PokeService : IPokeService
    {
        public async Task<string> GetAllPokes()
        {
            string pokeApi = "https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(pokeApi);

            var data = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject<PokeBaseDTO>(data);

            return data;
        }

        public async Task<string> ConsumePokeApi(string url)
        {
            string pokeApi = url;

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(pokeApi);

            var data = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject<PokeDetailDTO>(data);

            return data;
        }
    }
}