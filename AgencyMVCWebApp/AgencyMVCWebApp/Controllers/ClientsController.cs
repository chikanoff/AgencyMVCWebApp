using AgencyMVCWebApp.Data;
using AgencyMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyMVCWebApp.Controllers
{
    public class ClientsController : Controller
    {
        private courseworkDbContext db;

        public ClientsController(courseworkDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "CacheProfile")]
        public IActionResult Clients()
        {
            return View(db.Clients.Take(20).ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
