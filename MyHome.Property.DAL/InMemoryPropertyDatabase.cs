using MyHome.Common;
using MyHome.Property.Entities.Entities;
using MyHome.Property.Entities.Responses;
using System.Linq.Expressions;
using System.Text.Json;

namespace MyHome.Property.DAL
{
    public class InMemoryPropertyDatabase : IRepository<PropertyModel>
    {
        private readonly List<PropertyModel> _properties;

        public InMemoryPropertyDatabase()
        {
            string json = File.ReadAllText("..\\MyHome.Property.DAL\\ExampleData\\property_data.json");
            var data = JsonSerializer.Deserialize<SearchResponse>(json);
            _properties = data.SearchResults.ToList();
        }

        public async Task CreateAsync(PropertyModel entity)
        {
            entity.Id = _properties.ToArray().MaxBy(x => x.Id).Id + 1;
            _properties.Add(entity);
        }

        public async Task<IReadOnlyCollection<PropertyModel>> GetAllAsync()
        {
            //C:\WorkDev\MyHome.src\MyHome.Property.Service\MyHome.Property.Api\ExampleData\property_data.json
            return _properties.ToList();
        }

        public async Task<IReadOnlyCollection<PropertyModel>> GetAllAsync(Expression<Func<PropertyModel, bool>> filter)
        {
            var result = _properties.Where(filter.Compile()).ToList();
            return result;
        }

        public async Task<PropertyModel> GetAsync(int id)
        {
            return _properties.FirstOrDefault(p => p.Id == id);
        }

        public async Task<PropertyModel> GetAsync(Expression<Func<PropertyModel, bool>> filter)
        {
            return _properties.FirstOrDefault(filter.Compile());
        }

        public async Task RemoveAsync(int id)
        {
            var index = _properties.FindIndex(x => x.Id == id);
            _properties.RemoveAt(index);
        }

        public async Task UpdateAsync(PropertyModel entity)
        {
            var index = _properties.FindIndex(x => x.Id == entity.Id);
            var currentProperty = _properties[index];

            //TODO : Update fields
            var updatedProperty = entity; //Example only

            _properties[index] = updatedProperty;
        }
    }
}
