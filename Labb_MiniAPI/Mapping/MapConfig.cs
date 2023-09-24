using AutoMapper;
using Labb_MiniAPI.Models;
using Labb_MiniAPI.Models.DTOs;

namespace Labb_MiniAPI.Mapping
{
    public class MapConfig : Profile
    {
        public MapConfig() 
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
