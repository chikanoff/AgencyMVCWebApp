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
    public class TypesOfInsuranceController : Controller
    {
        private courseworkDbContext db;
        private readonly ILogger<TypesOfInsuranceController> _logger;

        public TypesOfInsuranceController(ILogger<TypesOfInsuranceController> logger, courseworkDbContext context)
        {
            _logger = logger;
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "CacheProfile")]
        public IActionResult TypesOfInsurance()
        {
            return View(db.TypesOfinsurance.Take(20).ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
