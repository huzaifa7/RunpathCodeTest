using System.Linq;
using System.Threading.Tasks;
using Moq;
using PhotoAlbumApi.Http;
using PhotoAlbumApi.Service;
using Xunit;
using Photo = PhotoAlbumApi.Http.Dto.Photo;

namespace PhotoAlbumApi.UnitTests.Service
{
    public class PhotoAlbumServiceShould
    {
        private Mock<IJsonPlaceHolderApiClient> apiClientMock;
        private PhotoAlbumService photoAlbumService;

        public PhotoAlbumServiceShould()
        {
            apiClientMock = new Mock<IJsonPlaceHolderApiClient>();
            photoAlbumService = new PhotoAlbumService(apiClientMock.Object);
        }

        [Fact]
        public async Task Call_JsonPlaceHolderApiClient_To_Get_All_Albums_Details()
        {
            // Act
            await photoAlbumService.GetDetails();

            // Assert
            apiClientMock.Verify(client => client.GetAlbums(), Times.Once);
        }

        [Fact]
        public async Task Call_JsonPlaceHolderApiClient_To_Get_All_Photo_Details()
        {
            // Act
            await photoAlbumService.GetDetails();

            // Assert
            apiClientMock.Verify(client => client.GetPhotos(), Times.Once);
        }

        [Fact]
        public async Task Call_JsonPlaceHolderApiClient_To_Get_Albums_For_A_Specific_User()
        {
            // Arrange
            int userId = 1;

            // Act
            await photoAlbumService.GetDetailsByUserId(userId);

            // Assert
            apiClientMock.Verify(client => client.GetAlbums(), Times.Once);
        }

        [Fact]
        public async Task Call_JsonPlaceHolderApiClient_To_Get_Photos_For_A_Specific_User()
        {
            // Arrange
            int userId = 1;

            // Act
            await photoAlbumService.GetDetailsByUserId(userId);

            // Assert
            apiClientMock.Verify(client => client.GetPhotos(), Times.Once);
        }

        [Fact]
        public async Task Return_Album_Collection_When_Getting_Details()
        {
            // Arrange
            var expectedAlbum = new Http.Dto.Album(1,1,"quidem molestiae enim");
            var expectedPhoto = new Photo(1,1,"accusamus beatae ad facilis cum similique qui sunt", "https://via.placeholder.com/600/92c952", "https://via.placeholder.com/150/92c952");
            apiClientMock.Setup(client => client.GetAlbums()).ReturnsAsync(new[]{expectedAlbum});
            apiClientMock.Setup(client => client.GetPhotos()).ReturnsAsync(new[]{expectedPhoto});

            // Act
            var albums = await photoAlbumService.GetDetails();

            // Assert
            var albumFound = albums.First();
            var photoFound = albumFound.Photos.First();
            Assert.Equal(expectedAlbum.Id, albumFound.Id);
            Assert.Equal(expectedAlbum.UserId, albumFound.UserId);
            Assert.Equal(expectedAlbum.Title, albumFound.Title);
            Assert.Equal(expectedPhoto.Id, photoFound.Id);
            Assert.Equal(expectedPhoto.Title, photoFound.Title);
            Assert.Equal(expectedPhoto.Url, photoFound.Url);
            Assert.Equal(expectedPhoto.ThumbnailUrl, photoFound.ThumbnailUrl);
        }
    }
}
