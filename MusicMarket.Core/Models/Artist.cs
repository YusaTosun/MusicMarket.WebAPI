using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core.Models
{
    public class Artist:BaseEntity
    {
        public Artist()
        {
            Musics = new Collection<Music>();
        }
        public string Name { get; set; }
        public ICollection<Music> Musics { get; set; }
    }
}
