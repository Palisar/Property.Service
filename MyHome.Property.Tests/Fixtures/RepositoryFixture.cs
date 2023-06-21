using MyHome.Property.Entities.Entities;

namespace MyHome.Property.Tests.Fixtures
{
    public static class RepositoryFixture
    {
        public static IReadOnlyCollection<PropertyModel> GetPropertyModels => new List<PropertyModel>()
        {
            new PropertyModel(){Id = 123},
            new PropertyModel(){Id = 321}
        };

        public static IReadOnlyCollection<PropertyModel> GetPropertyModelsById => new List<PropertyModel>()
        {
            new PropertyModel(){Id = 123}
        };

        public static PropertyModel GetFirstSingleProperty => new PropertyModel() { Id = 1 };
    };

}
