namespace PhotoAlbumApi.Http.Dto
{
    public class Photo
    {
        public int Id { get; }
        public int AlbumId { get; }
        public string Title { get; }
        public string Url { get; }
        public string ThumbnailUrl { get; }
        
        public Photo(int id, int albumId, string title, string url, string thumbnailUrl)
        {
            Id = id;
            AlbumId = albumId;
            Title = title;
            Url = url;
            ThumbnailUrl = thumbnailUrl;
        }
    }
}