using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PhotoAlbumApi.Controllers;
using PhotoAlbumApi.Model;
using PhotoAlbumApi.Service;
using Xunit;

namespace PhotoAlbumApi.UnitTests.Controllers
{
    public class PhotoAlbumControllerShould
    {
        [Fact]
        public async Task Call_PhotoAlbumService_To_Get_Album_Details_When_Get_Operation_Is_Invoked()
        {
            // Arrange
            var photoAlbumServiceMock = new Mock<IPhotoAlbumService>();
            var photoAlbumController = new PhotoAlbumController(photoAlbumServiceMock.Object);

            // Act
            await photoAlbumController.Get();

            // Assert
            photoAlbumServiceMock.Verify(service => service.GetDetails(), Times.Once);
        }

        [Fact]
        public async Task Return_Album_Collection_When_Get_Operration_Is_Invoked()
        {
            // Arrange
            var photoAlbumServiceMock = new Mock<IPhotoAlbumService>();
            var photoAlbumController = new PhotoAlbumController(photoAlbumServiceMock.Object);

            // Act
            var response = await photoAlbumController.Get();

            // Assert
            var okResponse = Assert.IsAssignableFrom<OkObjectResult>(response);
            Assert.IsAssignableFrom<IEnumerable<Album>>(okResponse.Value);
        }
        [Fact]
        public async Task Call_PhotoAlbumService_To_Get_Album_Details_When_Get_Operation_Is_Invoked_With_UserId()
        {
            // Arrange
            int userId = 1;
            var photoAlbumServiceMock = new Mock<IPhotoAlbumService>();
            var photoAlbumController = new PhotoAlbumController(photoAlbumServiceMock.Object);

            // Act
            await photoAlbumController.Get(userId);

            // Assert
            photoAlbumServiceMock.Verify(service => service.GetDetailsByUserId(userId), Times.Once);
        }

        [Fact]
        public async Task Return_Album_Collection_When_Get_Operration_Is_Invoked_With_UserId()
        {
            // Arrange
            int userId = 1;
            var photoAlbumServiceMock = new Mock<IPhotoAlbumService>();
            var photoAlbumController = new PhotoAlbumController(photoAlbumServiceMock.Object);

            // Act
            var response = await photoAlbumController.Get(userId);

            // Assert
            var okResponse = Assert.IsAssignableFrom<OkObjectResult>(response);
            Assert.IsAssignableFrom<IEnumerable<Album>>(okResponse.Value);
        }
    }
}
