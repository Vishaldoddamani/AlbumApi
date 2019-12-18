using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlbumApi.Models
{
    public class Album
    {
        public List<Photo> Photos { get; set; }
        public Album()
        {
            Photos = new List<Photo>();
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [Required]
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }

      
    }
}
