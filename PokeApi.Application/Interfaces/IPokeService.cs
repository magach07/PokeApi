using System.Threading.Tasks;

namespace PokeApi.Application.Interfaces
{
    public interface IPokeService
    {
        Task<string> GetAllPokes();
        Task<string> ConsumePokeApi(string url);
    }
}