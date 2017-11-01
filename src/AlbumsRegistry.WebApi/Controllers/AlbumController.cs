using System.Collections.Generic;
using AlbumsRegistry.Repository.Models;
using AlbumsRegistry.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlbumsRegistry.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Album")]
    public class AlbumController : Controller
    {
        private readonly IAlbumRepository _albumRepository; //todo: move to a service

        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        // GET: api/Album
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return _albumRepository.GetAlbums();
        }

        // GET: api/Album/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Album
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
