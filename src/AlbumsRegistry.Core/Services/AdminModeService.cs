using System;
using System.Web;
using AlbumsRegistry.Core.DataAccess.Repositories;

namespace AlbumsRegistry.Core.Services
{
    public class AdminModeService : IAdminModeService
    {
        private readonly IAdminModeRepository _adminModeRepository;
        private readonly string _cookieName = "am";
        private readonly string _cookieValue = "1";

        public AdminModeService(IAdminModeRepository adminModeRepository)
        {
            _adminModeRepository = adminModeRepository;
        }

        public bool IsPasswordValid(string password)
        {
            var adminModeInfo = _adminModeRepository.GetAdminModeInfo();
            return adminModeInfo.GetCleanPassword() == password;
        }

        public bool IsAdminModeActive(HttpCookieCollection cookies)
        {
            var adminModeInfo = _adminModeRepository.GetAdminModeInfo();
            var hours = adminModeInfo.ActiveSinceDate.GetValueOrDefault().Subtract(DateTime.UtcNow).Hours;
            var isCookieAdded = cookies[_cookieName] != null && cookies[_cookieName].Value == _cookieValue;

            return adminModeInfo.IsActive && hours < 6 && isCookieAdded;
        }

        public void ActivateAdminMode(HttpCookieCollection cookies)
        {
            var adminModeInfo = _adminModeRepository.GetAdminModeInfo();
            var dateTimeNow = DateTime.Now;

            adminModeInfo.IsActive = true;
            adminModeInfo.ActiveSinceDate = dateTimeNow;

            _adminModeRepository.SaveAdminModeInfo(adminModeInfo);

            cookies.Add(new HttpCookie(_cookieName)
            {
                Expires = dateTimeNow.AddHours(6),
                Value = _cookieValue
            });
        }

        public void DeactivateAdminMode(HttpCookieCollection requestCookies, HttpCookieCollection responseCookies)
        {
            var adminModeInfo = _adminModeRepository.GetAdminModeInfo();
            adminModeInfo.IsActive = false;
            adminModeInfo.ActiveSinceDate = null;
            _adminModeRepository.SaveAdminModeInfo(adminModeInfo);

            if (requestCookies[_cookieName] != null && responseCookies[_cookieName] != null)
            {
                responseCookies[_cookieName].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}