using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Settings.First());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Setting setting )
        {
            if (_context.Settings.Count() == 1)
            {
                ModelState.AddModelError("", "Yalniz 1 eded yarada bilersiniz!");
                return View(setting);
            }
            if(setting.HeaderResponsiveLogoFile==null || setting.HeaderLogoFile==null || setting.FooterLogoFile==null)
            {
                ModelState.AddModelError("","Sekillerin daxil edilmesi ile bagli problem askarlandi");
                return View(setting);
            }
            if (setting.HeaderResponsiveLogoFile != null)
            {
                if (setting.HeaderResponsiveLogoFile.ContentType != "image/png" && setting.HeaderResponsiveLogoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HeaderResponsiveLogoFile", "Mime type yanlisdir!");
                    return View();
                }

                if (setting.HeaderResponsiveLogoFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("HeaderResponsiveLogoFile", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + setting.HeaderResponsiveLogoFile.FileName;
                var path = Path.Combine(rootPath, "images/settingImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.HeaderResponsiveLogoFile.CopyTo(stream);
                }
                setting.HeaderResponsiveLogo = fileName;
            }
            if (setting.HeaderLogoFile != null)
            {
                if (setting.HeaderLogoFile.ContentType != "image/png" && setting.HeaderLogoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HeaderLogoFile", "Mime type yanlisdir!");
                    return View();
                }

                if (setting.HeaderLogoFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("HeaderLogoFile", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + setting.HeaderLogoFile.FileName;
                var path = Path.Combine(rootPath, "images/settingImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.HeaderLogoFile.CopyTo(stream);
                }
                setting.HeaderLogo = fileName;
            }
            if (setting.FooterLogoFile != null)
            {
                if (setting.FooterLogoFile.ContentType != "image/png" && setting.FooterLogoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("FooterLogoFile", "Mime type yanlisdir!");
                    return View();
                }

                if (setting.FooterLogoFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("FooterLogoFile", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + setting.FooterLogoFile.FileName;
                var path = Path.Combine(rootPath, "images/settingImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.FooterLogoFile.CopyTo(stream);
                }
                setting.FooterLogo = fileName;
            }

            _context.Settings.Add(setting);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Setting existSetting = _context.Settings.FirstOrDefault(x => x.Id == id);
            if (existSetting == null) return RedirectToAction("index");

            return View(existSetting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Setting setting)
        {
            Setting existSetting = _context.Settings.FirstOrDefault(x => x.Id == id);
            if (existSetting == null) return RedirectToAction("index");
            if (setting.HeaderResponsiveLogoFile != null)
            {
                if (setting.HeaderResponsiveLogoFile.ContentType != "image/png" && setting.HeaderResponsiveLogoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HeaderResponsiveLogoFile", "Mime type yanlisdir!");
                    return View();
                }

                if (setting.HeaderResponsiveLogoFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("HeaderResponsiveLogoFile", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + setting.HeaderResponsiveLogoFile.FileName;
                var path = Path.Combine(rootPath, "images/settingImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.HeaderResponsiveLogoFile.CopyTo(stream);
                }
                if (existSetting.HeaderResponsiveLogo != null)
                {
                    var existPath = Path.Combine(rootPath, "images/settingImage", existSetting.HeaderResponsiveLogo);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                    existSetting.HeaderResponsiveLogo = fileName;
                }
            }
            if (setting.HeaderLogoFile != null)
            {
                if (setting.HeaderLogoFile.ContentType != "image/png" && setting.HeaderLogoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HeaderLogoFile", "Mime type yanlisdir!");
                    return View();
                }

                if (setting.HeaderLogoFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("HeaderLogoFile", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + setting.HeaderLogoFile.FileName;
                var path = Path.Combine(rootPath, "images/settingImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.HeaderLogoFile.CopyTo(stream);
                }
                if (existSetting.HeaderLogo != null)
                {
                    var existPath = Path.Combine(rootPath, "images/settingImage", existSetting.HeaderLogo);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                    existSetting.HeaderLogo = fileName;
                }

            }
            if (setting.FooterLogoFile != null)
            {
                if (setting.FooterLogoFile.ContentType != "image/png" && setting.FooterLogoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("FooterLogoFile", "Mime type yanlisdir!");
                    return View();
                }

                if (setting.FooterLogoFile.Length > (1024 * 1024) * 5)
                {
                    ModelState.AddModelError("FooterLogoFile", "Faly olcusu 5MB-dan cox ola bilmez!");
                    return View();
                }
                string rootPath = _env.WebRootPath;
                var fileName = Guid.NewGuid().ToString() + setting.FooterLogoFile.FileName;
                var path = Path.Combine(rootPath, "images/settingImage", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    setting.FooterLogoFile.CopyTo(stream);
                }
                if (existSetting.FooterLogo != null)
                {
                    var existPath = Path.Combine(rootPath, "images/settingImage", existSetting.FooterLogo);
                    if (System.IO.File.Exists(existPath))
                    {
                        System.IO.File.Delete(existPath);
                    }
                    existSetting.FooterLogo = fileName;
                }
            }
            existSetting.Phone = setting.Phone;
            existSetting.Email = setting.Email;
            existSetting.FacebookUrl = setting.FacebookUrl;
            existSetting.LinkedinUrl = setting.LinkedinUrl;
            existSetting.InstagramUrl = setting.InstagramUrl;
            existSetting.TwitterUrl = setting.TwitterUrl;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Setting existSetting = _context.Settings.FirstOrDefault(x => x.Id == id);
            if (existSetting == null) return RedirectToAction("index");
            string rootPath = _env.WebRootPath;
            var existPath1 = Path.Combine(rootPath, "images/settingImage", existSetting.HeaderLogo);
            if (System.IO.File.Exists(existPath1))
            {
                System.IO.File.Delete(existPath1);
            }
            var existPath2 = Path.Combine(rootPath, "images/settingImage", existSetting.FooterLogo);
            if (System.IO.File.Exists(existPath2))
            {
                System.IO.File.Delete(existPath2);
            }
            var existPath3 = Path.Combine(rootPath, "images/settingImage", existSetting.HeaderResponsiveLogo);
            if (System.IO.File.Exists(existPath3))
            {
                System.IO.File.Delete(existPath3);
            }
            _context.Settings.Remove(existSetting);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
