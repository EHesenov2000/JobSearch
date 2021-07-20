using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using JobSearchFullWebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.BlogItems.ToList().Count() / 6m);
            List<BlogItem> blogItems = _context.BlogItems.Skip((page - 1) * 6).Take(6).ToList();

            return View(blogItems);
        }
        public IActionResult Detail(int id)
        {
            if (!_context.BlogItems.Any(x => x.Id == id))
            {
                return RedirectToAction("index", "home");
            }
            BlogDetailViewModel blogDetailViewModel = new BlogDetailViewModel
            {
                BlogItem = _context.BlogItems.Include(x => x.BlogItemLearns).Include(x => x.BlogItemRequirements).FirstOrDefault(x => x.Id == id),
                BlogItems = _context.BlogItems.OrderBy(x => x.CreatedAt).Take(3).ToList()
            }; 
            return View(blogDetailViewModel);
        }
    }
}
