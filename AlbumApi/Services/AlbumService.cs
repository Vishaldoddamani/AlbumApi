using AlbumApi.Entities;
using AlbumApi.Helpers;
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
    public class AlbumService(ILogger<AlbumService> _logger, IHttpClientHelper _httpClientHelper) : IAlbumService
    {
        private const string albumsUri = "http://jsonplaceholder.typicode.com/albums";
        private const string photoUri = "http://jsonplaceholder.typicode.com/photos";

        public async Task<List<AlbumDetails>> GetAlbumsAsync(int? UserId)
        {
            if (UserId == null)
            {
                throw new ArgumentNullException(nameof(UserId));
            }

            try
            {
                var listAlbum = await _httpClientHelper.GetAndDeserializeAsync<List<Album>>(albumsUri);
                var listPhotos = await _httpClientHelper.GetAndDeserializeAsync<List<Photo>>(photoUri);

                var userAlbums = (from album in listAlbum
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

                return userAlbums;
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "An error occurred while fetching albums or photos.");
                throw;
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "An error occurred while deserializing the response.");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                throw;
            }
        }
    }
}
