using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyHome.Common;
using MyHome.Property.Business.Interfaces;

using MyHome.Property.Entities.Entities;
using MyHome.Property.Entities.Requests;
using MyHome.Property.Entities.Responses;
using MyHome.Common.MongoDb;
namespace MyHome.Property.Business.Services
{
    public class PropertyService: IPropertyService
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
            var maxId = properties.MaxBy(x => x.Id).Id;

            createRequest.Model.Id = maxId + 1;
            await _repository.CreateAsync(createRequest.Model);

            return createRequest.Model;
        }
    }
}
