using System.Text.Json.Serialization;

namespace AlbumApi.Models
{
    public record Photo(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("albumId")] int AlbumId,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("thumbnailUrl")] string ThumbNailUrl);
}