using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumsRegistry.Model
{
    public class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public Artist Artist { get; set; }

        public Publisher Publisher { get; set; }

        public int TracksCount { get; set; }
    }
}
