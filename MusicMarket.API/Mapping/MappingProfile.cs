using AutoMapper;
using MusicMarket.API.DTO;
using MusicMarket.Core.Models;

namespace MusicMarket.API.Mapping
{
    public class MappingProfile:Profile
    {
       public MappingProfile() 
        {
            CreateMap<Music, MusicDTO>();  // todo: Reverse yapmak daha mı mantıklı olurdu.Validation Disabled olacak şekilde çalışıyor ???
            CreateMap<Artist, ArtistDTO>();

            CreateMap<MusicDTO, Music>();
            CreateMap<MusicDTO, Artist>();

            CreateMap<SaveMusicDTO, Music>();
            CreateMap<SaveArtistDTO, Artist>();

            CreateMap<SaveArtistDTO, MusicDTO>();

        }
    }
}
