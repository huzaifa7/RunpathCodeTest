using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhotoAlbumApi.Http.Dto;

namespace PhotoAlbumApi.Http
{
    public class JsonPlaceHolderApiClient : IJsonPlaceHolderApiClient
    {
        private readonly HttpClient _httpClient;

        public JsonPlaceHolderApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            var httpResponse = await _httpClient.GetAsync("/albums");
            return await DeserializeHttpContent<Album>(httpResponse);
        }

        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            var httpResponse = await _httpClient.GetAsync("/photos");
            return await DeserializeHttpContent<Photo>(httpResponse);
        }

        private static async Task<IEnumerable<T>> DeserializeHttpContent<T>(HttpResponseMessage httpResponse)
        {
            var jsonContent = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonContent);
        }
    }
}