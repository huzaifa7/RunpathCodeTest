using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using PhotoAlbumApi.Http;
using PhotoAlbumApi.Model;

namespace PhotoAlbumApi.Service
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private readonly IJsonPlaceHolderApiClient _jsonPlaceHolderApiClient;

        public PhotoAlbumService(IJsonPlaceHolderApiClient jsonPlaceHolderApiClient)
        {
            _jsonPlaceHolderApiClient = jsonPlaceHolderApiClient;
        }

        public async Task<IEnumerable<Album>> GetDetails()
        {
            var albums = await GetAlbums();
            var photos = await GetPhotos();

            return CreateAlbumCollection(albums, photos);
        }

        public async Task<IEnumerable<Album>> GetDetailsByUserId(int userId)
        {
            var albums = await GetAlbums();
            var photos = await GetPhotos();

            var albumsFilteredByUserId = albums.Where(album => album.UserId == userId);

            return CreateAlbumCollection(albumsFilteredByUserId, photos);
        }

        private static Collection<Album> CreateAlbumCollection(IEnumerable<Http.Dto.Album> albums, IEnumerable<Http.Dto.Photo> photos)
        {
            var albumCollection = new Collection<Album>();

            foreach (var album in albums)
            {
                var photosInAlbum = photos.Where(photo => photo.AlbumId == album.Id)
                    .Select(photo => new Photo(photo.Id, photo.Title, photo.Url, photo.ThumbnailUrl));
                var photoAlbum = new Album(album.Id, album.UserId, album.Title, photosInAlbum);
                albumCollection.Add(photoAlbum);
            }

            return albumCollection;
        }

        private async Task<IEnumerable<Http.Dto.Album>> GetAlbums()
        {
            var albums = await _jsonPlaceHolderApiClient.GetAlbums();
            return albums;
        }

        private async Task<IEnumerable<Http.Dto.Photo>> GetPhotos()
        {
            var photos = await _jsonPlaceHolderApiClient.GetPhotos();
            return photos;
        }
    }
}