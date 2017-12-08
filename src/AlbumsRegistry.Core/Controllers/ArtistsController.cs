using System.Net;
using System.Web.Mvc;
using AlbumsRegistry.Core.DataAccess.Repositories;
using AlbumsRegistry.Core.DataAccess.Repositories.FakeRepositories;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistsRepository _artistsRepository;

        public ArtistsController()
        {
            _artistsRepository = new FakeArtistsRepository();
        }

        // GET: Artists
        public ActionResult Index()
        {
            return View(_artistsRepository.GetArtists());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = _artistsRepository.GetArtistById(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _artistsRepository.CreateArtist(artist);
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = _artistsRepository.GetArtistById(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(artist).State = EntityState.Modified;
                //db.SaveChanges();
                _artistsRepository.UpdateArtist(artist);
                return RedirectToAction("Index");
            }
            return View(artist);
        }
    }
}
