using Clients.BackOffice.Proxies.Catalog;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clients.BackOffice.Controllers
{
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete()
        {
            return View();
        }
    }
}