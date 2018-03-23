using System.Collections.Generic;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.ViewModels
{
    public class AlbumsIndexViewModel
    {
        public IEnumerable<Album> Albums { get; set; }

        public string SearchFilter { get; set; }

        public int TotalCount { get; set; }
    }
}