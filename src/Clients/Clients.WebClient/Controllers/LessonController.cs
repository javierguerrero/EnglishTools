using Clients.WebClient.Proxies.Catalog;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clients.WebClient.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class LessonController : Controller
    {
        private readonly ICatalogProxy _catalogProxy;

        public LessonController(ICatalogProxy catalogProxy)
        {
            _catalogProxy = catalogProxy;
        }

        public async Task<IActionResult> Index(int page = 1, int take = 10)
        {
            var result = await _catalogProxy.GetLessonOverviewsAsync(page, take);
            return View(result);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _catalogProxy.GetLessonAsync(id);
            return View(result);
        }
    }
}