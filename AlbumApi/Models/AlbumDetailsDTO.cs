namespace AlbumApi.Services
{
    public class AlbumDetailsDTO
    {
        public string AlbumTitle { get; set; }
        public int UserId { get; set; }
        public string PhotoTitle { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoThumbNailUrl { get; set; }
    }
}