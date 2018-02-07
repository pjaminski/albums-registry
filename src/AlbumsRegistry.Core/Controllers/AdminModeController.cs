using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlbumsRegistry.Core.DataAccess.Repositories;
using AlbumsRegistry.Core.Models;
using AlbumsRegistry.Core.ViewModels;

namespace AlbumsRegistry.Core.Controllers
{
    public class AdminModeController : Controller
    {
        // GET: AdminMode
        public ActionResult Activate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Activate(ActivationAdminModeViewModel model)
        {
            var adminModeRepository = new AdminModeRepository();
            var adminModeInfo = adminModeRepository.GetAdminModeInfo();
           
            if (CheckValidPassword(model.Password, adminModeInfo.PasswordCore))
            {
                
            }

            model.ErrorMessage = Strings.AdminMode_Activate_Error;
            return View(model);
        }

        public ActionResult Deactivate()
        {
            //toastr pomaranczowy
            return View("Index", "Albums");
        }

        private bool CheckValidPassword(string password, string passwordCore)
        {
            //todo: decrypt passwordCore
            //todo: check if cleanPasswordCore contains password
            //todo: evaluate current suffix and compare with passed suffix

            return true;
        }

    }
}