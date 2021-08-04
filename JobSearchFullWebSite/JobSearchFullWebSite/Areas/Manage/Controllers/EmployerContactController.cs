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
    public class EmployerContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EmployerContactController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.EmployerContacts.Count() / 6m);

            return View(_context.EmployerContacts.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployerContact employerContact)
        {
            if (!ModelState.IsValid) return View(employerContact);
            _context.EmployerContacts.Add(employerContact);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Edit(int id)
        {
            EmployerContact existEmployerContact = _context.EmployerContacts.FirstOrDefault(x => x.Id == id);
            if (existEmployerContact == null) return RedirectToAction("index");

            return View(existEmployerContact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EmployerContact employerContact)
        {
            EmployerContact existEmployerContact = _context.EmployerContacts.FirstOrDefault(x => x.Id == id);
            if (existEmployerContact == null) return RedirectToAction("index");
            if (!ModelState.IsValid) return View(employerContact);
            existEmployerContact.Subject = employerContact.Subject;
            existEmployerContact.Email = employerContact.Email;
            existEmployerContact.Message = employerContact.Message;
            existEmployerContact.PhoneNumber = employerContact.PhoneNumber;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            EmployerContact existEmployerContact = _context.EmployerContacts.FirstOrDefault(x => x.Id == id);
            if (existEmployerContact == null) return RedirectToAction("index");
            _context.EmployerContacts.Remove(existEmployerContact);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
