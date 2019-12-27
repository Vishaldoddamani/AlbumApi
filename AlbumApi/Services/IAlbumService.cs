using System.Collections.Generic;
using System.Threading.Tasks;
using AlbumApi.Entities;
using AutoMapper;

namespace AlbumApi.Services
{
    public interface IAlbumService
    {
        IMapper _mapper { get; }

        Task<List<AlbumDetails>> GetAlbumsAsync(int? UserId);
    }
}