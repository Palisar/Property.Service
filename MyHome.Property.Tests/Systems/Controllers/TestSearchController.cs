using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHome.Property.Api.Controllers;
using MyHome.Property.Business.Interfaces;
using MyHome.Property.Entities.Entities;
using MyHome.Property.Entities.Requests;
using MyHome.Property.Entities.Responses;
using MyHome.Property.Tests.Fixtures;

namespace MyHome.Property.Tests.Systems.Controllers
{
    public class TestSearchController
    {
        private Mock<IPropertyService> mockPropertyService;

        public TestSearchController()
        {
            mockPropertyService = new Mock<IPropertyService>();
        }

        #region GetTests

        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange

            var mockSearchService = new Mock<IPropertyService>();
            var request = new SearchRequest();

            mockSearchService.Setup(service => service.GetAllProperties(request))
                .ReturnsAsync(PropertiesFixture.GetTestSearchResponse);
            var sut = new PropertyController(mockSearchService.Object);
            //Act
            var result = (OkObjectResult)await sut.GetSearchResultAsync(request);
            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesSearchServiceExactlyOnce()
        {
            //Arrange
            var request = new SearchRequest();

            mockPropertyService.Setup(service => service.GetAllProperties(request))
                .ReturnsAsync(PropertiesFixture.GetTestSearchResponse);

            var sut = new PropertyController(mockPropertyService.Object);
            //Act
            await sut.GetSearchResultAsync(request);
            //Assert
            mockPropertyService.Verify(service =>
                service.GetAllProperties(request),
                Times.Once()
                );
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfProperties()
        {
            //Arrange
            var request = new SearchRequest();

            mockPropertyService.Setup(service => service.GetAllProperties(request))
                .ReturnsAsync(PropertiesFixture.GetTestSearchResponse);

            var sut = new PropertyController(mockPropertyService.Object);

            //Act
            var result = await sut.GetSearchResultAsync(request);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<SearchResponse>();
        }

        [Fact]
        public async Task Get_OnNoPropertiesFound_Returns404()
        {
            //Arrange
            var request = new SearchRequest();

            mockPropertyService.Setup(service => service.GetAllProperties(request))
                .ReturnsAsync(PropertiesFixture.EmptySearchResponse);

            var sut = new PropertyController(mockPropertyService.Object);
            //Act
            var result = await sut.GetSearchResultAsync(request);

            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        #endregion

        #region PostTests
        [Fact]
        public async Task Post_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var sut = new PropertyController(mockPropertyService.Object);
            var request = new CreatePropertyRequest();
            request.Model = new PropertyModel();

            //Act
            var result = (OkObjectResult)await sut.PostPropertyAsync(request);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task Post_OnSuccess_InvokesPropertyServiceExactlyOnce()
        {
            //Arrange
            var request = new CreatePropertyRequest();
            request.Model = new PropertyModel();

            mockPropertyService.Setup(service => service.CreateProperty(request))
                .ReturnsAsync(new PropertyModel());

            var sut = new PropertyController(mockPropertyService.Object);
            //Act
            await sut.PostPropertyAsync(request);
            //Assert
            mockPropertyService.Verify(service =>
                service.CreateProperty(request),
                Times.Once()
                );
        }
        
        [Fact]
        public async Task Post_OnEmptyRequest_Returns400()
        {
            //Arrange
            var request = new CreatePropertyRequest();
            request.Model = null;

            mockPropertyService.Setup(service => service.CreateProperty(request))
                .ReturnsAsync(new PropertyModel());

            var sut = new PropertyController(mockPropertyService.Object);
            //Act
            var result = await sut.PostPropertyAsync(request);
            //Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        #endregion

        #region UpdateTests

        [Fact]
        public async Task Update_OnSuccess_ReturnsStatusCode204()
        {
            //Arrange
            var sut = new PropertyController(mockPropertyService.Object);
            var request = new UpdatePropertyRequest();
            request.UpdatedModel = new PropertyModel();

            mockPropertyService.Setup(service => service.UpdateProperty(request))
                .ReturnsAsync(true);

            //Act
            var result = (NoContentResult)await sut.UpdatePropertyAsync(request);

            //Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task Update_OnSuccess_InvokesPropertyServiceExactlyOnce()
        {
            //Arrange
            var request = new UpdatePropertyRequest();
            request.UpdatedModel = new PropertyModel();

            mockPropertyService.Setup(service => service.UpdateProperty(request))
                .ReturnsAsync(true);
            
            //Act
            var sut = new PropertyController(mockPropertyService.Object);
            await sut.UpdatePropertyAsync(request);

            //Assert
            mockPropertyService.Verify(service =>
                    service.UpdateProperty(request),
                Times.Once()
            );


        }

        [Fact]
        public async Task Update_OnEmptyRequest_Returns400()
        {
            //Arrange
            var request = new UpdatePropertyRequest();

            mockPropertyService.Setup(service => service.UpdateProperty(request))
                .ReturnsAsync(false);

            var sut = new PropertyController(mockPropertyService.Object);

            //Act
            var result = await sut.UpdatePropertyAsync(request);

            //Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task Update_OnInvalidProperty_Returns404()
        {
            //Arrange
            var request = new UpdatePropertyRequest();
            request.UpdatedModel = new PropertyModel();

            mockPropertyService.Setup(service => service.UpdateProperty(request))
                .ReturnsAsync(false);

            var sut = new PropertyController(mockPropertyService.Object);

            //Act
            var result = await sut.UpdatePropertyAsync(request);

            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        #endregion

        #region DeleteProperty
        [Fact]
        public async Task Delete_OnSuccess_ReturnsNoContent()
        {
            //Arrange
            var id = 123;

            var sut = new PropertyController(mockPropertyService.Object);
            
            mockPropertyService.Setup(service => service.DeleteProperty(id))
                .ReturnsAsync(true);

            //Act
            var result = await sut.DeletePropertyAsync(id);

            //Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task Delete_OnNegativeId_ReturnsBadRequest()
        {
            //Arrange
            var id = -123;

            var sut = new PropertyController(mockPropertyService.Object);

            //Act
            var result = await sut.DeletePropertyAsync(id);

            //Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task Delete_OnSuccess_InvokesPropertyServiceExactlyOnce()
        {
            //Arrange
            var id = 123;

            mockPropertyService.Setup(service => service.DeleteProperty(id))
                .ReturnsAsync(true);

            var sut = new PropertyController(mockPropertyService.Object);

            //Act
            var result = await sut.DeletePropertyAsync(id);

            //Assert
            mockPropertyService.Verify(service =>
                    service.DeleteProperty(id),
                Times.Once());
        }

       
        [Fact]
        public async Task Delete_IsDeletedIsFalse_ReturnsNotFound()
        {
            //Arrange
            var id = 123;

            mockPropertyService.Setup(service => service.DeleteProperty(id))
                .ReturnsAsync(false);

            var sut = new PropertyController(mockPropertyService.Object);

            //Act
            var result = await sut.DeletePropertyAsync(id);

            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        #endregion

    }
}
