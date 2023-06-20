using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHome.Property.Entities.Entities;
using MyHome.Property.Entities.Requests;
using MyHome.Property.Entities.Responses;

namespace MyHome.Property.Business.Interfaces
{
    public interface IPropertyService
    {
        Task<SearchResponse> GetAllProperties(SearchRequest request);
        Task<PropertyModel> CreateProperty(CreatePropertyRequest createRequest);
        //Task UpdateProperty(UpdatePropertyRequest updateRequest);
        //Task DeleteProperty(int id);

    }
}
