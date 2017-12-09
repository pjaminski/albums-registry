using System.Net;
using System.Web.Mvc;
using AlbumsRegistry.Core.DataAccess.Repositories;
using AlbumsRegistry.Core.DataAccess.Repositories.FakeRepositories;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsRepository _albumRepository;

        public AlbumsController()
        {
            _albumRepository = new FakeAlbumsRepository();
        }

        // GET: Albums
        public ActionResult Index()
        {
            return View(_albumRepository.GetAlbums());
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ReleaseYear,TracksCount")] Album album)
        {
            if (ModelState.IsValid)
            {
                _albumRepository.CreateAlbum(album);
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = _albumRepository.GetAlbumById(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleaseYear,TracksCount")] Album album)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(album).State = EntityState.Modified;
                //db.SaveChanges();
                _albumRepository.UpdateAlbum(album);
                return RedirectToAction("Index");
            }
            return View(album);
        }       
    }
}
