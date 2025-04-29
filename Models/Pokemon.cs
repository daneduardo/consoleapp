namespace ConsoleApp.Models
{
  public class Pokemon
{
    public required string Name { get; set; }
    public required List<PokemonTypeDetail> Types { get; set; }
}

public class PokemonTypeDetail
{
    public int Slot { get; set; }
    public required NamedApiResource Type { get; set; }
}

}
