using System.Net;
using System.Web.Mvc;
using AlbumsRegistry.Core.DataAccess.Repositories;
using AlbumsRegistry.Core.Models;
using AlbumsRegistry.Core.Services;

namespace AlbumsRegistry.Core.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistsRepository _artistsRepository;
        private readonly IAdminModeService _adminModeService;

        public ArtistsController(IArtistsRepository artistsRepository, IAdminModeService adminModeService)
        {
            _artistsRepository = artistsRepository;
            _adminModeService = adminModeService;
        }

        // GET: Artists
        public ActionResult Index()
        {
            return View(_artistsRepository.GetArtists());
        }    

        // GET: Artists/Create
        public ActionResult Create()
        {
            if (_adminModeService.IsAdminModeActive(HttpContext.Request.Cookies) == false)
            {
                return RedirectToAction("Activate", "AdminMode");
            }

            return View();
        }

        // POST: Artists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City")] Artist artist)
        {
            if (_adminModeService.IsAdminModeActive(HttpContext.Request.Cookies) == false)
            {
                return RedirectToAction("Activate", "AdminMode");
            }

            if (ModelState.IsValid == false)
            {
                return View(artist);
            }

            _artistsRepository.CreateArtist(artist);
            TempData["Msg"] = Strings.Artists_Index_Added;

            return RedirectToAction("Index");

        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (_adminModeService.IsAdminModeActive(HttpContext.Request.Cookies) == false)
            {
                return RedirectToAction("Activate", "AdminMode");
            }

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
            if (_adminModeService.IsAdminModeActive(HttpContext.Request.Cookies) == false)
            {
                return RedirectToAction("Activate", "AdminMode");
            }

            if (ModelState.IsValid == false)
            {
                return View(artist);
            }

            _artistsRepository.UpdateArtist(artist);
            TempData["Msg"] = Strings.General_ChangesSaved;

            return RedirectToAction("Index");
        }
    }
}
