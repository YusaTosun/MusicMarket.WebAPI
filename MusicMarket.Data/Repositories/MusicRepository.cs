using Microsoft.EntityFrameworkCore;
using MusicMarket.Core.Models;
using MusicMarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(DbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Music>> GetAllWithArtistAsync(int id)
        {
            return await dbContext.Set<Music>().Include(m => m.Artist).ToListAsync();
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await dbContext.Set<Music>().Include(m => m.Artist).Where(m => m.ArtistId.Equals(artistId)).ToListAsync();
        }

        public async Task<Music> GetWithArtistByIdAsync(int id)
        {
            return await dbContext.Set<Music>().FindAsync(id);
        }
        private MusicMarketDBContext dbContext
        {
            get { return context as MusicMarketDBContext; }
        }
    }
}
