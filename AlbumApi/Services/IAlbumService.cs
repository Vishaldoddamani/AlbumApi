using AlbumApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumApi.Services
{
    public interface IAlbumService
    {
        Task<List<AlbumDetails>> GetAlbumsAsync(int? UserId);
    }
}