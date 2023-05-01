using MusicMarket.Core.Models;
using MusicMarket.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Services.Abstract
{
    public interface IMusicService
    {
        Task<IEnumerable<MusicDTO>> GetAllWithArtist();
        Task<MusicDTO> GetMusicById(int Id);
        Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId);
        Task<MusicDTO> CreateMusic(SaveMusicDTO newMusicDTO);
        Task UpdateMusic(Music musicToBeUpdated,Music music);
        Task DeleteMusic(Music music);

    }
}
