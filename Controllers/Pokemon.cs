using Microsoft.AspNetCore.Mvc;
using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Controllers
{
   public class PokemonController : Controller
    {
        private readonly IPokeApiService _pokeApiService;

        public PokemonController(IPokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

            [HttpGet]
            public IActionResult Index()
            {
                return View(new PokemonViewModel());
            }


        // POST: Pokemon/Index
        [HttpPost]
        public async Task<IActionResult> Index(PokemonViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("", "Please enter a Pokémon name.");
                return View(model);
            }

            var result = await _pokeApiService.GetPokemonStrengthsAsync(model.Name.Trim().ToLower());

            if (result == null)
            {
            model.NotFound = true;
            Console.Write("Pokemon not found");
            ModelState.AddModelError(string.Empty, "Pokémon not found. Please check the name and try again.");
            return View(model);
            }

        return View("Index", result);
        }
    }

}
