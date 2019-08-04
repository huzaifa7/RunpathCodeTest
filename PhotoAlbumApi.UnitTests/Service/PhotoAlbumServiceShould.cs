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
        [Fact]
        public async Task Call_JsonPlaceHolderApiClient_To_Get_Albums_When_Getting_Details()
        {
            // Arrange
            var apiClientMock = new Mock<IJsonPlaceHolderApiClient>();
            var photoAlbumService = new PhotoAlbumService(apiClientMock.Object);

            // Act
            await photoAlbumService.GetDetails();

            // Assert
            apiClientMock.Verify(client => client.GetAlbums(), Times.Once);
        }

        [Fact]
        public async Task Call_JsonPlaceHolderApiClient_To_Get_Photos_When_Getting_Details()
        {
            // Arrange
            var apiClientMock = new Mock<IJsonPlaceHolderApiClient>();
            var photoAlbumService = new PhotoAlbumService(apiClientMock.Object);

            // Act
            await photoAlbumService.GetDetails();

            // Assert
            apiClientMock.Verify(client => client.GetPhotos(), Times.Once);
        }

        [Fact]
        public async Task Call_JsonPlaceHolderApiClient_To_Get_Albums_When_Getting_Details_For_A_User()
        {
            // Arrange
            var apiClientMock = new Mock<IJsonPlaceHolderApiClient>();
            var photoAlbumService = new PhotoAlbumService(apiClientMock.Object);
            int userId = 1;

            // Act
            await photoAlbumService.GetDetailsByUserId(userId);

            // Assert
            apiClientMock.Verify(client => client.GetAlbums(), Times.Once);
        }

        [Fact]
        public async Task Call_JsonPlaceHolderApiClient_To_Get_Photos_When_Getting_Details_For_A_User()
        {
            // Arrange
            var apiClientMock = new Mock<IJsonPlaceHolderApiClient>();
            var photoAlbumService = new PhotoAlbumService(apiClientMock.Object);
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
            var album = new Http.Dto.Album(1,1,"quidem molestiae enim");
            var photo = new Photo(1,1,"accusamus beatae ad facilis cum similique qui sunt", "https://via.placeholder.com/600/92c952", "https://via.placeholder.com/150/92c952");
            var apiClientMock = new Mock<IJsonPlaceHolderApiClient>();
            apiClientMock.Setup(client => client.GetAlbums()).ReturnsAsync(new[]{album});
            apiClientMock.Setup(client => client.GetPhotos()).ReturnsAsync(new[]{photo});

            var photoAlbumService = new PhotoAlbumService(apiClientMock.Object);

            // Act
            var albums = await photoAlbumService.GetDetails();

            // Assert
            Assert.Equal(album.Id, albums.First().Id);
            Assert.Equal(album.UserId, albums.First().UserId);
            Assert.Equal(album.Title, albums.First().Title);
            Assert.Equal(photo.Id, albums.First().Photos.First().Id);
            Assert.Equal(photo.Title, albums.First().Photos.First().Title);
            Assert.Equal(photo.Url, albums.First().Photos.First().Url);
            Assert.Equal(photo.ThumbnailUrl, albums.First().Photos.First().ThumbnailUrl);
        }
    }
}
