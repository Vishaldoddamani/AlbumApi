using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumApi.Services;
using AlbumApi.Entities;

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
