namespace MyHome.Property.Entities.Requests
{
    public class SearchRequest
    {
        public string Region { get; set; }
        public IEnumerable<string> LocalAreas { get; set; }
        public decimal MaxPrice { get; set; }
        public int MaxBeds { get; set; }

    }
}
