using JobSearchFullWebSite.Areas.Manage.ViewModels;
using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;

        }
        //public async Task<IActionResult> CreateSuperAdmin()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        UserName = "AdminElman2001",
        //        UserStatus=Enums.UserStatus.Admin
        //    };
        //    await _userManager.CreateAsync(admin, "7813432Elman");
        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");

        //    Admin admin1 = new Admin
        //    {
        //        FullName = "Elman Həsənov",
        //        AppUserId=admin.Id,
        //    };

        //    _context.Admins.Add(admin1);
        //    _context.SaveChanges();

        //    return Ok();
        //}
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginModel login)
        {
            AppUser adminUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == login.UserName && x.UserStatus==Enums.UserStatus.Admin);

            if (adminUser == null)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View(login);
            }

            var result = await _signInManager.PasswordSignInAsync(adminUser, login.Password, true, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View(login);
            }

            return RedirectToAction("index", "dashboard");
        }
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUser existUser =_context.Users.Include(x => x.Admin).FirstOrDefault(x => x.Id == user.Id);
            AdminEditModel editModel = new AdminEditModel
            {
                UserName=existUser.UserName,
                Password = existUser.Password,
                ConfirmedPassword = existUser.ConfirmedPassword,
                CurrentPassword = existUser.CurrentPassword,
                FullName = existUser.Admin.FullName
            };
            return View(editModel);
        }

        [Authorize(Roles = "Admin,SuperAdmin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminEditModel editModel)
        {
            AppUser admin = new AppUser
            {
                UserName=editModel.UserName,
                Password = editModel.Password,
                ConfirmedPassword = editModel.ConfirmedPassword,
                CurrentPassword = editModel.CurrentPassword,
            };


            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Admin existAdmin = _context.Admins.FirstOrDefault(x => x.AppUserId == user.Id);

            if (_userManager.Users.Any(x => x.UserName == admin.UserName && x.Id != user.Id))
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            if(existAdmin==null || existAdmin.FullName==null)
            {
                ModelState.AddModelError("Admin.FullName", "FullName is required");
                return View();
            }
            user.UserName = admin.UserName;
            existAdmin.FullName = editModel.FullName;
            //user.FullName = admin.FullName;


            if (!string.IsNullOrWhiteSpace(admin.Password))
            {
                if (string.IsNullOrWhiteSpace(admin.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword can not be emtpy");
                    return View();
                }

                var result = await _userManager.ChangePasswordAsync(user, admin.CurrentPassword, admin.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View();
                }
            }
            await _userManager.UpdateAsync(user);

            await _signInManager.SignInAsync(user, true);
            _context.SaveChanges();
            return RedirectToAction("login", "account");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
        [Authorize(Roles = "SuperAdmin")]

        public IActionResult CreateAdmin()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdmin(AdminRegisterModel registerModel)
        {

            //reqem,boyuk kicik herf,minimum 8 uzunluq,3 defe sehv yigma

            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser existUser = await _userManager.FindByNameAsync(registerModel.UserName);
            if (existUser != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken");
                return View();
            }
            AppUser newUser = new AppUser()
            {
                UserName = registerModel.UserName,
                UserStatus = Enums.UserStatus.Admin,
            };

            var result = await _userManager.CreateAsync(newUser, registerModel.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    if (item.Code == "PasswordTooShort")
                    {
                        item.Description = "Passwordun uzunlugu 8-den kicik ola bilmez";
                    }
                    else if (item.Description == "ConfirmedPassword and Password do not match.")
                    {
                        item.Description = "Alinmadi";
                    }
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newUser, "Admin");
            Admin admin = new Admin
            {
                FullName = registerModel.FullName,
                AppUserId=newUser.Id
            };
            _context.Admins.Add(admin);
            _context.SaveChanges();

            return RedirectToAction("getadmins");
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult GetAdmins(int page = 1)
        {
            ViewBag.SelectedPage = page;
            ViewBag.TotalPageCount = Math.Ceiling(_context.Users.Count() / 6m);
            List<AppUser> users = _userManager.Users.Skip((page - 1) * 4).Take(4).Where(x => x.UserStatus==Enums.UserStatus.Admin && x.UserName != User.Identity.Name).Include(X=>X.Admin).ToList();
            return View(users);
        }

        public IActionResult EditAdmin(string id)
        {
            //AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUser user = _context.Users.FirstOrDefault(x => x.Id == id.ToString());
            Admin admin = _context.Admins.FirstOrDefault(x => x.AppUserId == user.Id);
            AdminEditModel editModel = new AdminEditModel()
            {
                FullName = admin.FullName,
                UserName = user.UserName,
                Id = user.Id,
            };
            return View(editModel);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdmin(AdminEditModel admin)
        {
            //AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUser user = _context.Users.FirstOrDefault(x => x.Id == admin.Id);


            if (_userManager.Users.Any(x => x.UserName == admin.UserName && x.Id != user.Id))
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            Admin admin1 = _context.Admins.FirstOrDefault(x => x.AppUserId == user.Id);
            user.UserName = admin.UserName;
            admin1.FullName = admin.FullName;


            if (!string.IsNullOrWhiteSpace(admin.Password))
            {
                if (string.IsNullOrWhiteSpace(admin.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword can not be emtpy");
                    return View();
                }

                var result = await _userManager.ChangePasswordAsync(user, admin.CurrentPassword, admin.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View();
                }
            }
            await _userManager.UpdateAsync(user);
            _context.SaveChanges();
            //await _signInManager.SignInAsync(user, true);
            return RedirectToAction("getadmins");
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult DeleteAdmin(string id)
        {
            AppUser user = _context.Users.FirstOrDefault(x => x.Id == id);
            Admin admin = _context.Admins.FirstOrDefault(x => x.AppUserId == user.Id);
            if (user == null || admin==null) return RedirectToAction("getadmins");
            _context.Admins.Remove(admin);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("getadmins");
        }
    }
}
