using System.Net.Http.Json;
using ConsoleApp.Models;
using ConsoleApp.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class PokeApiService : IPokeApiService
{
    private readonly HttpClient _httpClient;

    public PokeApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PokemonViewModel?> GetPokemonStrengthsAsync(string pokemonName)
    {
        try
        {
                // Try to get the Pokémon data
                var pokemonData = await _httpClient.GetFromJsonAsync<Pokemon>($"https://pokeapi.co/api/v2/pokemon/{pokemonName.ToLower()}");

                if (pokemonData == null)
                {
                    return null;
                }

                var viewModel = new PokemonViewModel
                {
                    Name = pokemonData.Name,
                    Types = pokemonData.Types.Select(static t => t.Type.Name).ToList()
                };

                var strongAgainst = new HashSet<string>();
                var weakAgainst = new HashSet<string>();

                foreach (var typeEntry in pokemonData.Types)
                {
                    var typeName = typeEntry.Type.Name;
                    var typeInfo = await _httpClient.GetFromJsonAsync<TypeInfoSimple>($"https://pokeapi.co/api/v2/type/{typeName}");

                    if (typeInfo?.DamageRelations == null) continue;

                    // Strong against
                    foreach (var t in typeInfo.DamageRelations.DoubleDamageTo)
                        strongAgainst.Add(t.Name);

                    foreach (var t in typeInfo.DamageRelations.NoDamageFrom)
                        strongAgainst.Add(t.Name);

                    foreach (var t in typeInfo.DamageRelations.HalfDamageFrom)
                        strongAgainst.Add(t.Name);

                    // Weak against
                    foreach (var t in typeInfo.DamageRelations.NoDamageTo)
                        weakAgainst.Add(t.Name);

                    foreach (var t in typeInfo.DamageRelations.HalfDamageTo)
                        weakAgainst.Add(t.Name);

                    foreach (var t in typeInfo.DamageRelations.DoubleDamageFrom)
                        weakAgainst.Add(t.Name);
                }

                // Remove any overlaps from both sets
                strongAgainst.ExceptWith(weakAgainst);
                weakAgainst.ExceptWith(strongAgainst);

                viewModel.StrongAgainst = strongAgainst.OrderBy(x => x).ToList();
                viewModel.WeakAgainst = weakAgainst.OrderBy(x => x).ToList();

                return viewModel;
            
        }
        catch (HttpRequestException ex)
        {
            // Log the error or return null to indicate failure
            Console.WriteLine($"Error fetching data: {ex.Message}");
            return null;
        }
    }
}
