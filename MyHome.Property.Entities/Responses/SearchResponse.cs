using MyHome.Property.Entities.Entities;


namespace MyHome.Property.Entities.Responses
{
    public class SearchResponse
    {
        public IReadOnlyCollection<PropertyModel> SearchResults { get; set; }
    }
}
