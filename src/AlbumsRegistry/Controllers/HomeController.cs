using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlbumsRegistry.DAL;
using System.Data.Entity;

namespace AlbumsRegistry.Controllers
{
    public class HomeController : Controller
    {
        private AlbumsRegistryDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new AlbumsRegistryDbContext();
        }

        public ActionResult Index()
        {
            var albums = _dbContext.Albums
                .Include(a => a.Artist)
                .Include(a => a.Publisher);

            return View(albums);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}