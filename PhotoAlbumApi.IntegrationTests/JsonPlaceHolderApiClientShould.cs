using System;
using System.Net.Http;
using PhotoAlbumApi.Http;
using Xunit;

namespace PhotoAlbumApi.IntegrationTests
{
    public class JsonPlaceHolderApiClientShould
    {
        [Fact]
        public void Make_A_Call_To_Get_Album_Collection()
        {
            // Arrange
            var httpClient = new HttpClient(){BaseAddress = new Uri("http://jsonplaceholder.typicode.com")};
            var JsonPlaceHolderApiClient = new JsonPlaceHolderApiClient(httpClient);

            // Act
            var response = JsonPlaceHolderApiClient.GetAlbums();

            // Assert
        }
    }
}
