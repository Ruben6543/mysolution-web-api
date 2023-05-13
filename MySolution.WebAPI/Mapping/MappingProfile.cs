using AutoMapper;
using MySolution.Domain.DataTransferObject;
using MySolution.WebAPI.Models.Music;

namespace MySolution.WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Domain To Resource
            CreateMap<Music, MusicResponse>();

            //Resource to Domain
            CreateMap<MusicResponse, Music>();
        }
    }
}
