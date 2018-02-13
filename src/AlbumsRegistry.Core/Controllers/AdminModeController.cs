using System.Web.Mvc;
using AlbumsRegistry.Core.Services;
using AlbumsRegistry.Core.ViewModels;

namespace AlbumsRegistry.Core.Controllers
{
    public class AdminModeController : Controller
    {
        private readonly IAdminModeService _adminModeService;

        public AdminModeController(IAdminModeService adminModeService)
        {
            _adminModeService = adminModeService;
        }

        // GET: AdminMode
        public ActionResult Activate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Activate(ActivationAdminModeViewModel model)
        {      
            if (_adminModeService.IsPasswordValid(model.Password))
            {
                _adminModeService.ActivateAdminMode(HttpContext.Response.Cookies);
                return RedirectToAction("Index", "Albums");
            }

            model.ErrorMessage = Strings.AdminMode_Activate_Error;
            return View(model);
        }

        public ActionResult Deactivate()
        {
            _adminModeService.DeactivateAdminMode(HttpContext.Request.Cookies, HttpContext.Response.Cookies);
            return RedirectToAction("Index", "Albums");
        }
    }
}