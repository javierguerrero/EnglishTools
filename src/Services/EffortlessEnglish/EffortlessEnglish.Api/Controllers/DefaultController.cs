using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EffortlessEnglish.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Running...";
        }
    }
}