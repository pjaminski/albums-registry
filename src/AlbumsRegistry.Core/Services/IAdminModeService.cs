using System.Web;

namespace AlbumsRegistry.Core.Services
{
    public interface IAdminModeService
    {
        bool IsPasswordValid(string password);

        bool IsAdminModeActive();

        void ActivateAdminMode(HttpCookieCollection cookies);

        void DeactivateAdminMode(HttpCookieCollection requestCookies, HttpCookieCollection responseCookies);
    }
}
