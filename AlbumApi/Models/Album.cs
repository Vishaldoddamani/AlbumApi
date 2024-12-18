using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AlbumApi.Models
{
    public record Album(
       [property: JsonPropertyName("id")] int Id,
       [property: Required, JsonPropertyName("userId")] int UserId,
       [property: JsonPropertyName("title")] string Title,
       List<Photo> Photos = null)
    {
        public Album() : this(0, 0, string.Empty, new List<Photo>()) { }
    }
}