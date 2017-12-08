using System.Net;
using System.Web.Mvc;
using AlbumsRegistry.Core.DataAccess.Repositories;
using AlbumsRegistry.Core.DataAccess.Repositories.FakeRepositories;
using AlbumsRegistry.Core.Models;

namespace AlbumsRegistry.Core.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublishersRepository _publishersRepository;

        public PublishersController()
        {
            _publishersRepository = new FakePublishersRepository();
        }

        // GET: Publishers
        public ActionResult Index()
        {
            return View(_publishersRepository.GetPublishers());
        }

        // GET: Publishers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = _publishersRepository.GetPublisherById(id.Value);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // GET: Publishers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _publishersRepository.CreatePublisher(publisher);
                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = _publishersRepository.GetPublisherById(id.Value);
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
            if (ModelState.IsValid)
            {
                //db.Entry(publisher).State = EntityState.Modified;
                //db.SaveChanges();
                _publishersRepository.UpdatePublisher(publisher);
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
    }
}
