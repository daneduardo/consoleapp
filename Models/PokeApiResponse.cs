namespace ConsoleApp.Models
{
    public class PokeApiResponse
    {
        public string name { get; set; }=string.Empty;
        public required List<TypeInfo> types { get; set; }
    }

    public class TypeInfo
    {
        public int slot { get; set; }
        public required TypeDetail type { get; set; }
    }

    public class TypeDetail
    {
        public string name { get; set; }=string.Empty;
        public required string url { get; set; }
    }
}
