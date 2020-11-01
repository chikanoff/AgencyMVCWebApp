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
    public class PoliciesController : Controller
    {
        private courseworkDbContext db;
        private readonly ILogger<PoliciesController> _logger;

        public PoliciesController(ILogger<PoliciesController> logger, courseworkDbContext context)
        {
            _logger = logger;
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "CacheProfile")]
        public IActionResult Policies()
        {
            return View(db.Policies.Take(20).ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
