namespace PhotoAlbumApi.Http.Dto
{
    public class Album
    {
        public int Id { get; }
        public int UserId { get; }
        public string Title { get; }

        public Album(int id, int userId, string title)
        {
            Id = id;
            UserId = userId;
            Title = title;
        }
    }
}