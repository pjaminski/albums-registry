﻿using System.Linq;
using System.Net;
using System.Web.Mvc;
using AlbumsRegistry.Core.DataAccess.Repositories;
using AlbumsRegistry.Core.Models;
using AlbumsRegistry.Core.Services;
using AlbumsRegistry.Core.ViewModels;

namespace AlbumsRegistry.Core.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsRepository _albumsRepository;
        private readonly IArtistsRepository _artistsRepository;
        private readonly IPublishersRepository _publishersRepository;
        private readonly IAdminModeService _adminModeService;

        private const int PageSize = 40;

        public AlbumsController(
            IAlbumsRepository albumsRepository, 
            IArtistsRepository artistsRepository, 
            IPublishersRepository publishersRepository, 
            IAdminModeService adminModeService)
        {
            _albumsRepository = albumsRepository;
            _artistsRepository = artistsRepository;
            _publishersRepository = publishersRepository;
            _adminModeService = adminModeService;
        }

        // GET: Albums
        public ActionResult Index(int page = 0)
        {
            var albums = _albumsRepository.GetAlbums().ToList();
            var albumsTotalCount = albums.Count;
            var pageResult = albums.Skip(page * PageSize).Take(PageSize);

            ViewBag.MaxPage = albumsTotalCount / PageSize - (albumsTotalCount % PageSize == 0 ? 1 : 0);
            ViewBag.Page = page;

            return View(new AlbumsIndexViewModel
            {
                Albums = pageResult,
                TotalCount = albumsTotalCount
            });
        }
    
        // GET: Albums/Create
        public ActionResult Create()
        {
            if (_adminModeService.IsAdminModeActive(HttpContext.Request.Cookies) == false)
            {
                return RedirectToAction("Activate", "AdminMode");
            }

            ViewBag.ArtistId = new SelectList(_artistsRepository.GetArtists(), "Id", "Name");
            ViewBag.PublisherId = new SelectList(_publishersRepository.GetPublishers(), "Id", "Name");
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ReleaseYear,ArtistId,PublisherId,TracksCount")] Album album)
        {
            if (_adminModeService.IsAdminModeActive(HttpContext.Request.Cookies) == false)
            {
                return RedirectToAction("Activate", "AdminMode");
            }

            if (ModelState.IsValid)
            {
                _albumsRepository.CreateAlbum(album);
                TempData["Msg"] = Strings.Albums_Index_Added;
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(_artistsRepository.GetArtists(), "Id", "Name", album.ArtistId);
            ViewBag.PublisherId = new SelectList(_publishersRepository.GetPublishers(), "Id", "Name", album.PublisherId);
            return View(album);
        }

        // GET: Albums/Edit/5
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

            var album = _albumsRepository.GetAlbumById(id.Value);

            if (album == null)
            {
                return HttpNotFound();
            }

            ViewBag.ArtistId = new SelectList(_artistsRepository.GetArtists(), "Id", "Name", album.ArtistId);
            ViewBag.PublisherId = new SelectList(_publishersRepository.GetPublishers(), "Id", "Name", album.PublisherId);
            return View(album);
        }

        // POST: Albums/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleaseYear,ArtistId,PublisherId,TracksCount")] Album album)
        {
            if (_adminModeService.IsAdminModeActive(HttpContext.Request.Cookies) == false)
            {
                return RedirectToAction("Activate", "AdminMode");
            }

            if (ModelState.IsValid)
            {
                _albumsRepository.UpdateAlbum(album);
                TempData["Msg"] = Strings.General_ChangesSaved;
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(_artistsRepository.GetArtists(), "Id", "Name", album.ArtistId);
            ViewBag.PublisherId = new SelectList(_publishersRepository.GetPublishers(), "Id", "Name", album.PublisherId);
            return View(album);
        }

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToAction("Index");
            }

            var searchedAlbums = _albumsRepository.GetAlbumsBySearchTerm(searchTerm).ToList();

            return View("Index",
                new AlbumsIndexViewModel()
                {
                    Albums = searchedAlbums,
                    SearchFilter = searchTerm,
                    TotalCount = searchedAlbums.Count
                }
            );
        }
    }
}
