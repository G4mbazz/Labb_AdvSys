using AutoMapper;
using ModelsLib.Models;

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
