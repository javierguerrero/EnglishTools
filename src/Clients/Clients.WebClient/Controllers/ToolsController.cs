﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clients.WebClient.Controllers
{
    public class ToolsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}