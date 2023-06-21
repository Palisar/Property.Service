using MyHome.Common;
using MyHome.Property.Business.Interfaces;

using MyHome.Property.Entities.Entities;
using MyHome.Property.Entities.Requests;
using MyHome.Property.Entities.Responses;

namespace MyHome.Property.Business.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository<PropertyModel> _repository;
        public PropertyService(IRepository<PropertyModel> repository)
        {
            _repository = repository;
        }

        public async Task<SearchResponse> GetAllProperties(SearchRequest request)
        {
            var searchResponse = new SearchResponse();

            var properties = await _repository.GetAllAsync();

            //TODO : Some logic to find the list 
            searchResponse.SearchResults = properties;

            return searchResponse;
        }

        public async Task<PropertyModel> CreateProperty(CreatePropertyRequest createRequest)
        {

            var properties = await _repository.GetAllAsync();
            int maxId;

            if (!properties.Any())
            {
                //Edge Case: Database was empty
                maxId = 0;
            }
            else
            {
                maxId = properties.MaxBy(p => p.Id).Id;
            }

            createRequest.Model.Id = maxId + 1;

            await _repository.CreateAsync(createRequest.Model);

            return createRequest.Model;
        }

        public async Task<bool> UpdateProperty(UpdatePropertyRequest updateRequest)
        {
            try
            {
                var existingProperty = await _repository
                    .GetAllAsync(x => x.Id == updateRequest.UpdatedModel.Id);

                if (!existingProperty.Any()) return false;

                await _repository.UpdateAsync(updateRequest.UpdatedModel);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProperty(int id)
        {
            try
            {
                var existingProperty = await _repository
                    .GetAllAsync(x => x.Id == id);

                if (!existingProperty.Any()) return false;

                await _repository.RemoveAsync(id);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
