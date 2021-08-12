using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCore.Controllers
{
    public class TestController : Controller
    {
        //[Route("foo/bar")]
        public string Index()
        {
            return "Hello Controller";
        }
        public IActionResult details(int id)
        {
            if (id == 0)
            {
                return NotFound($"There is no id = {id}");
            }
            return Ok($"You sent id = {id}");
        }
        public IActionResult status()
        {
            //return BadRequest("Bad request");
            //return Unauthorized("Hello unauthorised useer");
            //return new UnsupportedMediaTypeResult();
            return Redirect("details/1234");
        }
        public IActionResult JsonResult()
        {
            return Json(new
            {
                message = " This is a Json message",
                date = DateTime.Now
            });
        }
        public IActionResult ContentResult()
        {
            return Content("<h1>This is a content</h1>");
        }
        public IActionResult MyAction()
        {
            List<string> list = new List<string>
            {
                "string #1",
                "string #2",
                "string #3",
                "string #4",
                "string #5",
            };
            return View(list);
        }
    }
}
