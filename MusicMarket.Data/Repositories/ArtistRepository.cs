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
    public class ArtistRepository:Repository<Artist>,IArtistRepository
    {
        public ArtistRepository(DbContext _context):base(_context)
        {
            
        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await dbContext.Set<Artist>().Include(x=>x.Musics).ToListAsync();
        }

        public async Task<Artist> GetWithMusicByIdAsync(int id)
        {
            return await dbContext.Set<Artist>().Include(x=>x.Musics).Where(x=>x.Id.Equals(id)).FirstOrDefaultAsync();
        }
        private MusicMarketDBContext dbContext
        {
            get { return context as MusicMarketDBContext; }
        }
    }
}
