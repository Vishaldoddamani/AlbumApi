using System.Text.Json.Serialization;

namespace AlbumApi.Models
{
    public class Photo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("albumId")]
        public int AlbumId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("thumbnailUrl")]
        public string ThumbNailUrl { get; set; }
    }
}