using AutoMapper;
using MusicMarket.Core.Models;
using MusicMarket.Services.Abstract;
using MusicMarket.Services.DTO;

namespace MusicMarketApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Music,MusicDTO>();
            CreateMap<Artist,ArtistDTO>();

            CreateMap<MusicDTO, Music>();
            CreateMap<ArtistDTO, Artist>();
            
            
            CreateMap<SaveMusicDTO,Music>();
            CreateMap<SaveArtistDTO,Artist>();

            CreateMap<SaveMusicDTO, Music>();
            CreateMap<Music, SaveMusicDTO>();

            CreateMap<UpdateMusicDTO, Music>();
            CreateMap<Music, UpdateMusicDTO>();
        }
    }
}
