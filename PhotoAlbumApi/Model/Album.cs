using System.Collections.Generic;
using PhotoAlbumApi.Http;
using PhotoAlbumApi.Http.Dto;

namespace PhotoAlbumApi.Model
{
    public class Album
    {
        public int Id { get; }
        public int UserId { get; }
        public string Title { get; }
        public IEnumerable<Photo> Photos { get; }

        public Album(int id, int userId, string title, IEnumerable<Photo> photos)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Photos = photos;
        }
    }
}