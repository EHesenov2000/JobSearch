using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class JobContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public JobContactController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.JobContacts.Count() / 6m);

            return View(_context.JobContacts.ToList()) ;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobContact jobContact)
        {
            if (!ModelState.IsValid) return View(jobContact) ;
            _context.JobContacts.Add(jobContact);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Edit(int id)
        {
            JobContact existJobContact = _context.JobContacts.FirstOrDefault(x => x.Id == id);
            if (existJobContact == null) return RedirectToAction("index");

            return View(existJobContact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,JobContact jobContact)
        {
            JobContact existJobContact = _context.JobContacts.FirstOrDefault(x => x.Id == id);
            if (existJobContact == null) return RedirectToAction("index");
            if (!ModelState.IsValid) return View(jobContact);
            existJobContact.Subject = jobContact.Subject;
            existJobContact.Email = jobContact.Email;
            existJobContact.Message = jobContact.Message;
            existJobContact.PhoneNumber = jobContact.PhoneNumber;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            JobContact existJobContact = _context.JobContacts.FirstOrDefault(x => x.Id == id);
            if (existJobContact == null) return RedirectToAction("index");
            _context.JobContacts.Remove(existJobContact);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
