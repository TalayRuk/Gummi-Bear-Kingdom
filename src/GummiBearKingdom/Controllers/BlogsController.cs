using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBearKingdom.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GummiBearKingdom.Controllers
{
    public class BlogsController : Controller
    {
        // GET: /<controller>/
        private GummiBearDbContext _context;
        public BlogsController(GummiBearDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Blogs.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }
    }
}
