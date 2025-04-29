namespace ConsoleApp.Models
{
    public class PokemonViewModel
    {
        public bool NotFound { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<string> Types { get; set; } = new();
        public List<string> StrongAgainst { get; set; } = new();
        public List<string> WeakAgainst { get; set; } = new();
    }
}
