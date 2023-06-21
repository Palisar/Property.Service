using MyHome.Property.Entities.Entities;
using MyHome.Property.Entities.Responses;

namespace MyHome.Property.Tests.Fixtures
{
    public static class PropertiesFixture
    {
        public static SearchResponse GetTestSearchResponse() => new()
        {
            SearchResults = new List<PropertyModel>()
            {
                new PropertyModel
                {
                    Id = 120
                },
                new PropertyModel
                {
                    Id =  123
                }
            }
        };

        public static SearchResponse EmptySearchResponse() => new()
        {
            SearchResults = new List<PropertyModel>()
        };




    }
}
