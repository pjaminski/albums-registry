using System.Net;
using System.Web.Mvc;
using AlbumsRegistry.Core.DataAccess.Repositories;
using AlbumsRegistry.Core.Models;
using AlbumsRegistry.Core.Services;

namespace AlbumsRegistry.Core.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublishersRepository _publishersRepository;
        private readonly IAdminModeService _adminModeService;

        public PublishersController(IPublishersRepository publishersRepository, IAdminModeService adminModeService)
        {
            _publishersRepository = publishersRepository;
            _adminModeService = adminModeService;
        }

        // GET: Publishers
        public ActionResult Index()
        {
            return View(_publishersRepository.GetPublishers());
        }

        // GET: Publishers/Create
        public ActionResult Create()
        {
            if (_adminModeService.IsAdminModeActive(HttpContext.Request.Cookies) == false)
            {
                return RedirectToAction("Activate", "AdminMode");
            }

            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City")] Publisher publisher)
        {
            if (_adminModeService.IsAdminModeActive(HttpContext.Request.Cookies) == false)
            {
                return RedirectToAction("Activate", "AdminMode");
            }

            if (ModelState.IsValid == false)
            {
                return View(publisher);
            }

            _publishersRepository.CreatePublisher(publisher);
            TempData["Msg"] = Strings.Publishers_Index_Added;

            return RedirectToAction("Index");
        }

        // GET: Publishers/Edit/5
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

            var publisher = _publishersRepository.GetPublisherById(id.Value);

            if (publisher == null)
            {
                return HttpNotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City")] Publisher publisher)
        {
            if (_adminModeService.IsAdminModeActive(HttpContext.Request.Cookies) == false)
            {
                return RedirectToAction("Activate", "AdminMode");
            }

            if (ModelState.IsValid == false)
            {
                return View(publisher);
            }

            _publishersRepository.UpdatePublisher(publisher);
            TempData["Msg"] = Strings.General_ChangesSaved;

            return RedirectToAction("Index");
        }
    }
}
