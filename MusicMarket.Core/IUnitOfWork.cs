using MusicMarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core
{
    internal interface IUnitOfWork:IDisposable
    {
         IMusicRepository Musics { get; set; }
         IArtistRepository Artists { get; set; }

        Task<int> CommitAsync();
    }
}
