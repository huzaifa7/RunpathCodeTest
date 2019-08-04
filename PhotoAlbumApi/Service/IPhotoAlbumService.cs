using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoAlbumApi.Model;

namespace PhotoAlbumApi.Service
{
    public interface IPhotoAlbumService
    {
        Task<IEnumerable<Album>> GetDetails();
        Task<IEnumerable<Album>> GetDetailsByUserId(int userId);
    }
}