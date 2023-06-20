using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
