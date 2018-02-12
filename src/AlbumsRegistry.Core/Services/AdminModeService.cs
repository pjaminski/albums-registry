using System;
using System.Web;
using AlbumsRegistry.Core.DataAccess.Repositories;

namespace AlbumsRegistry.Core.Services
{
    public class AdminModeService : IAdminModeService
    {
        private readonly IAdminModeRepository _adminModeRepository;

        public AdminModeService(IAdminModeRepository adminModeRepository)
        {
            _adminModeRepository = adminModeRepository;
        }

        public bool IsPasswordValid(string password)
        {
            //todo: decrypt passwordCore
            //todo: check if cleanPasswordCore contains password
            //todo: evaluate current suffix and compare with passed suffix

            return true;
        }

        public bool IsAdminModeActive()
        {
            throw new NotImplementedException();
        }

        public void ActivateAdminMode(HttpCookieCollection cookies)
        {
            var adminModeInfo = _adminModeRepository.GetAdminModeInfo();
            var dateTimeNow = DateTime.Now;

            if (adminModeInfo != null)
            {
                adminModeInfo.IsActive = true;
                adminModeInfo.ActiveSinceDate = dateTimeNow;

                _adminModeRepository.SaveAdminModeInfo(adminModeInfo);
            }

            cookies.Add(new HttpCookie("am")
            {
                Expires = dateTimeNow.AddHours(6),
                Value = "1"
            });
        }

        public void DeactivateAdminMode(HttpCookieCollection requestCookies, HttpCookieCollection responseCookies)
        {
            //var adminModeInfo = _adminModeRepository.GetAdminModeInfo();
            //adminModeInfo.IsActive = false;
            //adminModeInfo.ActiveSinceDate = null;
            //_adminModeRepository.SaveAdminModeInfo(adminModeInfo);

            if (requestCookies["am"] != null && responseCookies["am"] != null)
            {
                responseCookies["am"].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}