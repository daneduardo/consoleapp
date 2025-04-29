using System.Text.Json.Serialization;
namespace ConsoleApp.Models
{
    public class TypeInfoSimple
    {
         [JsonPropertyName("damage_relations")]
        public required DamageRelations DamageRelations { get; set; }
    }
}