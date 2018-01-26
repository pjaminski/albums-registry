using System.Net;
using System.Web.Mvc;
using AlbumsRegistry.Core.DataAccess.Repositories;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistsRepository _artistsRepository;

        public ArtistsController(IArtistsRepository artistsRepository)
        {
            _artistsRepository = artistsRepository;
        }

        // GET: Artists
        public ActionResult Index()
        {
            return View(_artistsRepository.GetArtists());
        }    

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
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

            var artist = _artistsRepository.GetArtistById(id.Value);

            if (artist == null)
            {
                return HttpNotFound();
            }

            return View(artist);
        }

        // POST: Artists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City")] Artist artist)
        {
            if (ModelState.IsValid)
            {;
                _artistsRepository.UpdateArtist(artist);
                TempData["Msg"] = Strings.General_ChangesSaved;
                return RedirectToAction("Index");
            }

            return View(artist);
        }
    }
}
