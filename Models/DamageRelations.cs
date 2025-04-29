using System.Text.Json.Serialization;
namespace ConsoleApp.Models
{
public class DamageRelations
{
    [JsonPropertyName("double_damage_to")]
    public required List<NamedApiResource> DoubleDamageTo { get; set; }

    [JsonPropertyName("double_damage_from")]
    public required List<NamedApiResource> DoubleDamageFrom { get; set; }

    [JsonPropertyName("half_damage_to")]
    public required List<NamedApiResource> HalfDamageTo { get; set; }

    [JsonPropertyName("half_damage_from")]
    public required List<NamedApiResource> HalfDamageFrom { get; set; }

    [JsonPropertyName("no_damage_to")]
    public required List<NamedApiResource> NoDamageTo { get; set; }

    [JsonPropertyName("no_damage_from")]
    public required List<NamedApiResource> NoDamageFrom { get; set; }
}
}