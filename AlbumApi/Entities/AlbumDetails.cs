using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumApi.Entities
{
    public class AlbumDetails
    {
        public string AlbumTitle { get; set; }
        public int UserId { get; set; }
        public string PhotoTitle { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoThumbNailUrl { get; set; }

    }
}
