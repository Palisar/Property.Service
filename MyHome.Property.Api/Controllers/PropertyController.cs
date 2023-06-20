using Microsoft.AspNetCore.Mvc;
using MyHome.Property.Business.Interfaces;
using MyHome.Property.Entities.Requests;

namespace MyHome.Property.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        public async Task<IActionResult> GetSearchResultAsync(SearchRequest request)
        {
            var properties = await _propertyService.GetAllProperties(request);

            if (!properties.SearchResults.Any())
                return NotFound();

            return Ok(properties);
        }
        [HttpPost]
        public async Task<IActionResult> PostPropertyAsync(CreatePropertyRequest request)
        {
            if (request.Model is null)
                return BadRequest();

            var property = await _propertyService.CreateProperty(request);
            return Ok(property);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePropertyAsync(UpdatePropertyRequest request)
        {
            if(request.UpdatedModel is null)
                return BadRequest();

            await _propertyService.UpdateProperty(request);

            return NoContent();
        }
    }
}
