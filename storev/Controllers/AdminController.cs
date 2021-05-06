using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using storev.Models;
using storev.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace storev.Controllers
{
    [System.Web.Mvc.Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private RoleStore<IdentityRole> roleStore;
        private RoleManager<IdentityRole> roleManager;
        private UserStore<ApplicationUser> userStore;
        private UserManager<ApplicationUser> userManager;
        public static string roleName;


        public AdminController()
        {
            _context = new ApplicationDbContext();
            roleStore = new RoleStore<IdentityRole>(_context);
            roleManager = new RoleManager<IdentityRole>(roleStore);
        }
        // GET: Admin
        public ActionResult Index()
        {
            var roles = roleManager.Roles.ToList();

            return View(roles);
        }

        [ValidateAntiForgeryToken]
        public ActionResult SaveRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return Content("Role name couldn't be empty!!");

            if (!roleManager.RoleExists(roleName))
                roleManager.Create(new IdentityRole(roleName));

            return RedirectToAction("index");
        }

        public ActionResult ShowUsers(string id)
        {
            roleName = id;
            var allUsers = _context.Users;

            return View(allUsers);
        } 
        
        public ActionResult ShowAllUsers()
        {
            var vm = (from u in _context.Users
                      select new
                      {
                          UserId = u.Id,
                          Name = u.Name,
                          Email = u.Email,
                          RoleNames = (from ur in u.Roles
                                       join r in _context.Roles on ur.RoleId
                                       equals r.Id
                                       select r.Name).ToList()
                      }).ToList().Select(p => new UserRolesVM() { 
                        UserId = p.UserId,
                        Name = p.Name,
                        Email = p.Email,
                        Role = string.Join(",",p.RoleNames)
                      });              
                      
            return View(vm);
        }


        public ActionResult AddUserToRole(string id)
        {
            userStore = new UserStore<ApplicationUser>(_context);
            userManager = new UserManager<ApplicationUser>(userStore);
            userManager.AddToRole(id, roleName);

            return Content("Added Successfully!");
        }
    }
}