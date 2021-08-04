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
    public class CandidateContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CandidateContactController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(_context.CandidateContacts.Count() / 6m);

            return View(_context.CandidateContacts.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CandidateContact candidateContact)
        {
            if (!ModelState.IsValid) return View(candidateContact);
            _context.CandidateContacts.Add(candidateContact);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Edit(int id)
        {
            CandidateContact existCandidateContact = _context.CandidateContacts.FirstOrDefault(x => x.Id == id);
            if (existCandidateContact == null) return RedirectToAction("index");

            return View(existCandidateContact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CandidateContact candidateContact)
        {
            CandidateContact existCandidateContact = _context.CandidateContacts.FirstOrDefault(x => x.Id == id);
            if (existCandidateContact == null) return RedirectToAction("index");
            if (!ModelState.IsValid) return View(candidateContact);
            existCandidateContact.Subject = candidateContact.Subject;
            existCandidateContact.Email = candidateContact.Email;
            existCandidateContact.Message = candidateContact.Message;
            existCandidateContact.PhoneNumber = candidateContact.PhoneNumber;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            CandidateContact existCandidateContact = _context.CandidateContacts.FirstOrDefault(x => x.Id == id);
            if (existCandidateContact == null) return RedirectToAction("index");
            _context.CandidateContacts.Remove(existCandidateContact);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
