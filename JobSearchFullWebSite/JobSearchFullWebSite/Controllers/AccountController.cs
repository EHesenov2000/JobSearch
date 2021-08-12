using JobSearchFullWebSite.DAL.AppDbContext;
using JobSearchFullWebSite.Models;
using JobSearchFullWebSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchFullWebSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole identityRole1 = new IdentityRole("Candidate");
        //    IdentityRole identityRole2 = new IdentityRole("Employer");
        //    IdentityRole identityRole3 = new IdentityRole("Admin");
        //    IdentityRole identityRole4 = new IdentityRole("SuperAdmin");


        //    await _roleManager.CreateAsync(identityRole1);
        //    await _roleManager.CreateAsync(identityRole2);
        //    await _roleManager.CreateAsync(identityRole3);
        //    await _roleManager.CreateAsync(identityRole4);

        //    return Content("ok");
        //}
        public IActionResult CandidateRegister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CandidateRegister(CandidateRegisterModel candidateModel)
        {
            //reqem,boyuk kicik herf,minimum 8 uzunluq,3 defe sehv yigma
            if (!ModelState.IsValid)
            {
                
                ModelState.AddModelError("", "Formu duzgun doldurun");
                return View();
            }

            AppUser existUser = await _userManager.FindByNameAsync(candidateModel.UserName);
            if (existUser != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken");
                return View();
            }
            AppUser newUser = new AppUser()
            {
                UserName = candidateModel.UserName,
                UserStatus=Enums.UserStatus.Candidate
            };

            var result = await _userManager.CreateAsync(newUser, candidateModel.Password);

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
                        item.Description = "Confirm ve ya Password duzgun deyil";
                    }
                    else if(item.Description== "Passwords must have at least one uppercase ('A'-'Z').")
                    {
                        item.Description = "Passwordda en azi bir boyuk herf isletmelisiz";
                    }
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            Candidate candidate = new Candidate
            {
                AppUserId = newUser.Id
            };
            _context.Candidates.Add(candidate);
            await _userManager.AddToRoleAsync(newUser, "Candidate");
            await _signInManager.SignInAsync(newUser, true);
            _context.SaveChanges();
            return RedirectToAction("index", "home");
        }
        public IActionResult EmployerRegister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployerRegister(EmployerRegisterModel employerModel)
        {
            //reqem,boyuk kicik herf,minimum 8 uzunluq,3 defe sehv yigma
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("", "Formu duzgun doldurun");
                return View();
            }

            AppUser existUser = await _userManager.FindByNameAsync(employerModel.UserName);
            if (existUser != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken");
                return View();
            }
            AppUser newUser = new AppUser()
            {
                UserName = employerModel.UserName,
                UserStatus=Enums.UserStatus.Employer
            };

            var result = await _userManager.CreateAsync(newUser, employerModel.Password);

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
                        item.Description = "Confirm ve ya Password duzgun deyil";
                    }
                    else if (item.Description == "Passwords must have at least one uppercase ('A'-'Z').")
                    {
                        item.Description = "Passwordda en azi bir boyuk herf isletmelisiz";
                    }
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            Employer employer = new Employer
            {
                AppUserId = newUser.Id
            };
            _context.Employers.Add(employer);
            await _userManager.AddToRoleAsync(newUser, "Employer");
            await _signInManager.SignInAsync(newUser, true);
            _context.SaveChanges();

            return RedirectToAction("index", "home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(CandidateAndEmployerLoginModel loginModel)
        {

            AppUser user = await _userManager.FindByNameAsync(loginModel.UserName);
            if (user == null || user.UserStatus==Enums.UserStatus.Admin)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }
            //yeniden girdikde usernamenin gorunmesini ozum teyin edirem asagida
            loginModel.IsPersistent = true;
            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.IsPersistent, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            return RedirectToAction("index", "home");
        }

        [Authorize(Roles = "Candidate,Employer")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index","home");
        }

        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> CandidateEdit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            CandidateEditModel candidate = new CandidateEditModel
            {
                UserName = user.UserName,
                AppUser = user,
            };
            return View(candidate);
        }
        [Authorize(Roles = "Candidate")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CandidateEdit(CandidateEditModel candidate)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (_userManager.Users.Any(x => x.UserName == candidate.UserName && x.Id != user.Id))
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            user.UserName = candidate.UserName;


            if (!string.IsNullOrWhiteSpace(candidate.Password))
            {
                if (string.IsNullOrWhiteSpace(candidate.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword can not be emtpy");
                    return View();
                }

                var result = await _userManager.ChangePasswordAsync(user, candidate.CurrentPassword, candidate.Password);
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
            return RedirectToAction("index", "home");
        }

        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> EmployerEdit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            EmployerEditModel candidate = new EmployerEditModel
            {
                UserName = user.UserName,
                AppUser = user,
            };

            return View(candidate);
        }
        [Authorize(Roles = "Employer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployerEdit(EmployerEditModel employer)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (_userManager.Users.Any(x => x.UserName == employer.UserName && x.Id != user.Id))
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            user.UserName = employer.UserName;


            if (!string.IsNullOrWhiteSpace(employer.Password))
            {
                if (string.IsNullOrWhiteSpace(employer.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword can not be emtpy");
                    return View();
                }

                var result = await _userManager.ChangePasswordAsync(user, employer.CurrentPassword, employer.Password);
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
            return RedirectToAction("index", "home");
        }
    }
}
