using Microsoft.OpenApi.Services;
using MyHome.Common;
using MyHome.Property.Business.Services;
using MyHome.Property.Entities.Entities;
using MyHome.Property.Entities.Requests;
using MyHome.Property.Tests.Fixtures;

namespace MyHome.Property.Tests.Systems.Services
{
    public class TestPropertyService
    {
        private Mock<IRepository<PropertyModel>> mockRepository;

        public TestPropertyService()
        {
            mockRepository = new Mock<IRepository<PropertyModel>>();
        }
        #region GetAllProperties

        [Fact]
        public async Task GetAllProperties_WhenCalled_InvokesRepositoryGetAllAsync()
        {
            //arrange
            var request = new SearchRequest();
            
            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(RepositoryFixture.GetPropertyModels);

            var sut = new PropertyService(mockRepository.Object);

            //act
            await sut.GetAllProperties(request);
            //assert
            mockRepository.Verify(repo =>
                    repo.GetAllAsync(),
                Times.Once()
            );
        }

        [Fact]
        public async Task GetAllProperties_WhenCalled_ReturnsListOfPropertyModel()
        {
            //arrange
            var request = new SearchRequest();

            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(RepositoryFixture.GetPropertyModels);

            var sut = new PropertyService(mockRepository.Object);
            //act
            var response = await sut.GetAllProperties(request);

            //assert
            response.SearchResults.Should().BeOfType<List<PropertyModel>>();
        }

        #endregion

        #region CreateProperty

        [Fact]
        public async Task CreateProperty_WhenCalled_InvokesRepositoryCreateAsync()
        {
            //arrange
            var request = new CreatePropertyRequest();
            request.Model = new PropertyModel();

            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(RepositoryFixture.GetPropertyModels);

            mockRepository.Setup(repo => repo.CreateAsync(request.Model))
                .Returns(Task.FromResult(new PropertyModel())
                );

            var sut = new PropertyService(mockRepository.Object);

            //act
            await sut.CreateProperty(request);

            //assert
            mockRepository.Verify(repo =>
                    repo.CreateAsync(request.Model),
                Times.Once()
            );
        }

        [Fact]
        public async Task CreateProperty_WhenCalled_ReturnsNewlyCreatedProperty()
        {
            //arrange
            var request = new CreatePropertyRequest();
            request.Model = new PropertyModel();

            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(RepositoryFixture.GetPropertyModels);

            mockRepository.Setup(repo => repo.CreateAsync(request.Model))
                .Returns(Task.FromResult(new PropertyModel())
                );

            var sut = new PropertyService(mockRepository.Object);

            //act
            var result = await sut.CreateProperty(request);

            //assert
            result.Should().BeOfType<PropertyModel>();
            result.Id.Should().Be(322);//To show that a new Id has been assigned
        }
        #endregion

        #region UpdateProperty
        [Fact]
        public async Task UpdateProperty_WhenCalled_InvokesRepositoryGetAllAsyncWithFilterOnce()
        {
            //arrange
            var request = new UpdatePropertyRequest();
            request.UpdatedModel = new PropertyModel();

            mockRepository.Setup(repo =>
                    repo.GetAllAsync(x => x.Id == request.UpdatedModel.Id))
                .ReturnsAsync(RepositoryFixture.GetPropertyModels);
                        

            var sut = new PropertyService(mockRepository.Object);

            //act
            await sut.UpdateProperty(request);

            //assert
            mockRepository.Verify(repo =>
                    repo.GetAllAsync(x => x.Id == request.UpdatedModel.Id),
                Times.Once()
            );
        }

        [Fact]
        public async Task UpdateProperty_WhenCalled_InvokesRepositoryUpdateAsyncOnce()
        {
            //arrange
            var request = new UpdatePropertyRequest();
            request.UpdatedModel = new PropertyModel();

            mockRepository.Setup(repo =>
                    repo.GetAllAsync(x => x.Id == request.UpdatedModel.Id))
                .ReturnsAsync(RepositoryFixture.GetPropertyModels);

            mockRepository.Setup(repo =>
                    repo.UpdateAsync(request.UpdatedModel))
                .Returns(Task.CompletedTask);

            var sut = new PropertyService(mockRepository.Object);

            //act
            await sut.UpdateProperty(request);

            //assert
            mockRepository.Verify(repo =>
                    repo.UpdateAsync(request.UpdatedModel),
                Times.Once()
            );
        }
      
        [Fact]
        public async Task UpdateProperty_WhenNotPropertyFound_ReturnFalse()
        {
            //arrange
            var request = new UpdatePropertyRequest();
            request.UpdatedModel = new PropertyModel(){Id = 123};

            mockRepository.Setup(repo => 
                    repo.GetAllAsync(x => x.Id == request.UpdatedModel.Id))
                .ReturnsAsync(new List<PropertyModel>());

            mockRepository.Setup(repo => repo.UpdateAsync(request.UpdatedModel))
                .Returns(Task.FromResult(new PropertyModel())
                );

            var sut = new PropertyService(mockRepository.Object);

            //act
            var result = await sut.UpdateProperty(request);

            //assert
            result.Should().BeFalse();
        }
        [Fact]
        public async Task UpdateProperty_WhenExceptionThrown_ReturnFalse()
        {
            //arrange
            var request = new UpdatePropertyRequest();
            request.UpdatedModel = new PropertyModel() { Id = 123 };

            mockRepository.Setup(repo =>
                    repo.GetAllAsync(x => x.Id == request.UpdatedModel.Id))
                .ReturnsAsync(new List<PropertyModel>());

            mockRepository.Setup(repo => repo.UpdateAsync(request.UpdatedModel))
                .Throws<Exception>()
                ;

            var sut = new PropertyService(mockRepository.Object);

            //act
            var result = await sut.UpdateProperty(request);

            //assert
            result.Should().BeFalse();
        }
        #endregion

        #region DeleteProperty

        

        #endregion
    }
}
