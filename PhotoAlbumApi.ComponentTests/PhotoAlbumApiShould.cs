using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhotoAlbumApi.Model;
using Xunit;

namespace PhotoAlbumApi.ComponentTests
{
    public class PhotoAlbumApiShould
    {
        public PhotoAlbumApiShould()
        {
            //TODO: Startup the PhotoAlbumApi before running the testss => dotnet test .\PhotoAlbumApi.ComponentTests\.
            //TODO: Going forward, create a dockerfile for the PhotoAlbumApi & this project and use docker-compose to spin-up the api before running these tests
        }

        [Fact]
        public async Task Return_An_Ok_Response_With_Album_Collection_When_Making_Api_Call_To_Get_All_Information()
        {
            // Arrange
            var photoAlbumApiClient = new HttpClient(){BaseAddress = new Uri("https://localhost:44334/")};

            // Act
            var response =
                await photoAlbumApiClient.GetAsync("api/photoalbum");
            
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var albums = await DeserializeHttpContent(response);
            Assert.IsAssignableFrom<IEnumerable<Album>>(albums);
        }

        [Fact]
        public async Task Return_An_Ok_Response_With_Album_Collection_When_Making_Api_Call_With_User_Id()
        {
            // Arrange
            var photoAlbumApiClient = new HttpClient(){BaseAddress = new Uri("https://localhost:44334/")};
            int userId = 1;

            // Act
            var response =
                await photoAlbumApiClient.GetAsync($"api/photoalbum/{userId}");
            
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var albums = await DeserializeHttpContent(response);
            Assert.IsAssignableFrom<IEnumerable<Album>>(albums);
        }

        private static async Task<IEnumerable<Album>> DeserializeHttpContent(HttpResponseMessage response)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(jsonContent);
            return albums;
        }
    }
}
