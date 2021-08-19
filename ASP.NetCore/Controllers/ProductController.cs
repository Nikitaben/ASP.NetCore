using ASP.NetCore.Data.Interfaces;
using ASP.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;
        private readonly IVendorRepo _vendorRepo;

        public ProductController(IProductRepo productRepo, IVendorRepo vendorRepo)
        {
            _productRepo = productRepo;
            _vendorRepo = vendorRepo;
        }
        public IActionResult Index()
        {
            var vendors = _vendorRepo.GetAllVendors();
            var list = _productRepo.GetAllProducts()
                .Select(p =>
                {
                    p.Vendor = vendors.Where(v => v.V_code == p.V_code)
                    .FirstOrDefault() ?? new Vendor
                    {
                        V_name = "n/a"
                    };
                    return p;
                })
                .ToList();



            return View(list);
        }
        public IEnumerable<string> GetProductsByVendorId(int? id)
        {
            var res = _productRepo.GetAllProducts()
                .Where(p => p.V_code == id)
                .Select(p => p.P_descript + "\n");
            if(res == null || res.Count() == 0)
            {
                return new List<string> { "No Product found" };
            }
            return res;
        }
        public ActionResult Create()
        {
            ViewBag.Vendors =
                new SelectList(_vendorRepo.GetAllVendors().ToList(),
                "V_Code", "V_name");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            _productRepo.CreateProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
