using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoAlbumApi.Http.Dto;

namespace PhotoAlbumApi.Http
{
    public interface IJsonPlaceHolderApiClient
    {
        Task<IEnumerable<Album>> GetAlbums();
        Task<IEnumerable<Photo>> GetPhotos();
    }
}