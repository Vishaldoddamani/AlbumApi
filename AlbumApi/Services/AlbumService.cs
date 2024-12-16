using AlbumApi.Entities;
using AlbumApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace AlbumApi.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly ILogger logger;
        private readonly IHttpClientFactory httpClientFactory;

        public AlbumService(ILogger _logger, IHttpClientFactory httpClientFactory)
        {
            logger = _logger;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<AlbumDetails>> GetAlbumsAsync(int? UserId)
        {
            List<AlbumDetails> userAlbums = null;

            if (UserId == null)
            {
                throw new ArgumentNullException(nameof(UserId));
            }

            try
            {
                var clientFactory = httpClientFactory.CreateClient();

                HttpResponseMessage responseAlbums = await clientFactory.GetAsync("http://jsonplaceholder.typicode.com/albums");
                responseAlbums.EnsureSuccessStatusCode();

                HttpResponseMessage responsePhotos = await clientFactory.GetAsync("http://jsonplaceholder.typicode.com/photos");
                responsePhotos.EnsureSuccessStatusCode();

                string albums = await responseAlbums.Content.ReadAsStringAsync();
                string photos = await responsePhotos.Content.ReadAsStringAsync();

                var listAlbum = JsonSerializer.Deserialize<List<Album>>(albums);
                var listPhotos = JsonSerializer.Deserialize<List<Photo>>(photos);

                userAlbums = (from album in listAlbum
                              join photo in listPhotos
                              on album.Id equals photo.AlbumId
                              select new AlbumDetails
                              {
                                  AlbumTitle = album.Title,
                                  UserId = album.UserId,
                                  PhotoTitle = photo.Title,
                                  PhotoUrl = photo.Url,
                                  PhotoThumbNailUrl = photo.ThumbNailUrl
                              }).Where(x => x.UserId == UserId).ToList();
            }
            catch (HttpRequestException httpEx)
            {
                logger.LogError(httpEx, "An error occurred while fetching albums or photos.");
                throw;
            }
            catch (JsonException jsonEx)
            {
                logger.LogError(jsonEx, "An error occurred while deserializing the response.");
                throw;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An unexpected error occurred.");
                throw;
            }

            return userAlbums;
        }
    }
}