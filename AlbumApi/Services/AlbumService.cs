using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AlbumApi.Entities;
using AlbumApi.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace AlbumApi.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly List<AlbumDetails> userAlbums;
        private List<Album> listAlbum;
        private List<Photo> listPhotos;

        public IMapper _mapper => throw new NotImplementedException();

        public async Task<List<AlbumDetails>> GetAlbumsAsync(int? UserId)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseAlbums = await client.GetAsync("http://jsonplaceholder.typicode.com/albums");

                HttpResponseMessage responsePhotos = await client.GetAsync("http://jsonplaceholder.typicode.com/photos");

                responseAlbums.EnsureSuccessStatusCode();

                string albums = await responseAlbums.Content.ReadAsStringAsync();
                string photos = await responsePhotos.Content.ReadAsStringAsync();

                listAlbum = JsonConvert.DeserializeObject<List<Album>>(albums);
                listPhotos = JsonConvert.DeserializeObject<List<Photo>>(photos);


                var albumDetails = from album in listAlbum
                                   join photo in listPhotos
                                   on album.Id equals photo.AlbumId
                                   select new AlbumDetailsDTO
                                   {
                                       AlbumTitle = album.Title,
                                       UserId = album.UserId,
                                       PhotoTitle = photo.Title,
                                       PhotoUrl = photo.Url,
                                       PhotoThumbNailUrl = photo.ThumbNailUrl
                                   };

                var userAlbums = albumDetails?.Where(x => x.UserId == UserId).ToList();

                // userAlbums = _mapper.Map<List<AlbumDetails>>(userAlbums);
            }

            return userAlbums;
        }
    }
}
