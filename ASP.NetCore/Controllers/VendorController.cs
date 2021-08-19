using ASP.NetCore.Data.Interfaces;
using ASP.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCore.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorRepo _vendorRepo;

        public VendorController(IVendorRepo vendorRepo)
        {
            _vendorRepo = vendorRepo;
        }
        public IActionResult Index()
        {
            return View(_vendorRepo.GetAllVendors());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Vendor input)
        {
            _vendorRepo.CreateVendor(input);
            return RedirectToAction(nameof(Index));
        }
    }
}
