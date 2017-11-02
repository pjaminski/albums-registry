using System.Collections.Generic;
using AlbumsRegistry.Model;
using AlbumsRegistry.WebApi.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlbumsRegistry.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : Controller
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        // GET api/Album
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return _albumRepository.GetAlbums();
        }

        // GET api/Album/5
        [HttpGet("{id}")]
        public Album Get(int id)
        {
            return _albumRepository.GetAlbumById(id);
        }

        // POST api/Album
        [HttpPost]
        public void Post([FromBody]Album album)
        {
            _albumRepository.CreateAlbum(album);
        }

        // PUT api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Album album)
        {
            _albumRepository.UpdateAlbum(album);
        }
    }
}
