using AlbumApi.Entities;
using AlbumApi.Services;
using AutoMapper;

namespace AlbumApi.Profiles
{
    public class AlbumDetailsProfile : Profile
    {
        public AlbumDetailsProfile()
        {
            CreateMap<AlbumDetails, AlbumDetailsDTO>();
        }
    }
}