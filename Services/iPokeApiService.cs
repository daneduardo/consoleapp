using ConsoleApp.Models;

namespace ConsoleApp.Services
{
    public interface IPokeApiService
    {
        Task<PokemonViewModel?> GetPokemonStrengthsAsync(string name);
    }
}
