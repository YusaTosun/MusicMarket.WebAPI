using MusicMarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Services.Abstract
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllArtists();
        Task<Artist> GetArtistById(int id); 
        Task<Artist> CreateArtist(Artist artist); 
        Task UpdateArtist(Artist artistToBeUpdated,Artist artist);
        Task DeleteArtist(Artist artist);
    }
}
