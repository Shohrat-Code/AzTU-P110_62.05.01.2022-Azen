using Azen.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azen.Areas.admin.Controllers
{ 
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.Include(c=>c.ProductCategory).Include(b=>b.Brand).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Category = _context.ProductCategories.ToList();
            ViewBag.Brand = _context.Brands.ToList();
            return View();
        }
    }
}
