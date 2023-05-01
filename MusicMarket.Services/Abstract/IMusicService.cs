using MusicMarket.Common.ResponseObjects;
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
        Task<IResponse<IEnumerable<MusicDTO>>> GetAllWithArtist();
        Task<MusicDTO> GetMusicById(int Id);
        Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId);
        Task<IResponse<SaveMusicDTO>> CreateMusic(SaveMusicDTO newMusicDTO);
        Task<Response> UpdateMusic(UpdateMusicDTO musicToBeUpdated, int id);
        Task<IResponse> DeleteMusic(int id);

    }
}
