using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients.WebClient.Proxies.EffortlessEnglish;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clients.WebClient.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    [Route("effortless-english")]
    public class EffortlessEnglishController : Controller
    {
        private readonly IEffortlessEnglishProxy _effortlessEnglishProxy;

        public EffortlessEnglishController(IEffortlessEnglishProxy effortlessEnglishProxy)
        {
            _effortlessEnglishProxy = effortlessEnglishProxy;
        }

        public async Task<IActionResult> Index(int page = 1, int take = 10)
        {
            var result = await _effortlessEnglishProxy.GetAllAsync(page, take);
            return View(result);
        }
    }
}