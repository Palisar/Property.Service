using MyHome.Property.Entities.Entities;
using MyHome.Property.Entities.Requests;
using MyHome.Property.Entities.Responses;

namespace MyHome.Property.Business.Interfaces
{
    public interface IPropertyService
    {
        Task<SearchResponse> GetAllProperties(SearchRequest request);
        Task<PropertyModel> CreateProperty(CreatePropertyRequest createRequest);
        Task<bool> UpdateProperty(UpdatePropertyRequest updateRequest);
        Task<bool> DeleteProperty(int id);

    }
}
