﻿using System.Net;
using System.Web.Mvc;
using AlbumsRegistry.Core.DataAccess.Repositories;
using AlbumsRegistry.Core.DataAccess.Repositories.FakeRepositories;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsRepository _albumsRepository;
        private readonly IArtistsRepository _artistsRepository;
        private readonly IPublishersRepository _publishersRepository;

        public AlbumsController(IAlbumsRepository albumsRepository, IArtistsRepository artistsRepository, IPublishersRepository publishersRepository)
        {
            _albumsRepository = albumsRepository;
            _artistsRepository = artistsRepository;
            _publishersRepository = publishersRepository;
        }

        // GET: Albums
        public ActionResult Index()
        {
            return View(_albumsRepository.GetAlbums());
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(_artistsRepository.GetArtists(), "Id", "Name");
            ViewBag.PublisherId = new SelectList(_publishersRepository.GetPublishers(), "Id", "Name");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ReleaseYear,ArtistId,PublisherId,TracksCount")] Album album)
        {
            if (ModelState.IsValid)
            {
                _albumsRepository.CreateAlbum(album);
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(_artistsRepository.GetArtists(), "Id", "Name", album.ArtistId);
            ViewBag.PublisherId = new SelectList(_publishersRepository.GetPublishers(), "Id", "Name", album.PublisherId);
            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleaseYear,ArtistId,PublisherId,TracksCount")] Album album)
        {
            if (ModelState.IsValid)
            {
                _albumsRepository.UpdateAlbum(album);
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(_artistsRepository.GetArtists(), "Id", "Name", album.ArtistId);
            ViewBag.PublisherId = new SelectList(_publishersRepository.GetPublishers(), "Id", "Name", album.PublisherId);
            return View(album);
        }        
    }
}
