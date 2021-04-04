using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using POS.Models;
using POS.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

        private readonly UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public UserController()
        {
        }

        // GET: Admin/User
        public ActionResult Index(string role)
        {
            switch (role)
            {
                case null:
                    return View(GetAllUser());
                case "All":
                    return View(GetAllUser());
                default:
                    return View(GetAllUserByRole(role));
            }
        }

        public JsonResult GetAllRole()
        {
            var roles = this._roleManager.Roles.ToList();
            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(string id)
        {
            return View(GetUserById(id));
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(this._roleManager.Roles, "Id", "Name");
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
            try
            {
                // TODO: Add insert logic here
                var user = new ApplicationUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email,
                    EmailConfirmed = true,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    PhoneNumber = viewModel.PhoneNumber,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };
                var result = this._userManager.Create(user, viewModel.Password);
                if (result.Succeeded)
                {
                    this._userManager.AddToRole(user.Id, viewModel.Role);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                throw new HttpException(404, "Id not found");
            }

            var user = GetUserById(id);

            if (user == null)
            {
                throw new HttpException(404, "Service not found");
            }

            ViewBag.Roles = new SelectList(this._roleManager.Roles.ToList(), "Name", "Name");
            return View(user);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, UserViewModel viewModel)
        {
            try
            {
                // TODO: Add update logic here
                var user = new ApplicationUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email,
                    EmailConfirmed = true,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    PhoneNumber = viewModel.PhoneNumber,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                var result = this._userManager.Update(user);
                if (result.Succeeded)
                {
                    this._userManager.AddToRole(user.Id, viewModel.Role);
                }
                ViewBag.Roles = new SelectList(this._roleManager.Roles.ToList(), "Name", "Name");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Admin/User/Delete/5
        [HttpPost]


        public ActionResult Delete(string id, UserViewModel viewModel)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IEnumerable<UserViewModel> GetAllUserByRole(string role)
        {
            var usersInRole = _userManager.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(role)).ToList();

            IList<UserViewModel> userlistByRole = new List<UserViewModel>();
            foreach (var item in usersInRole)
            {
                userlistByRole.Add(UserDTO.ConvertToViewModel(item));
            }
            return userlistByRole;
        }
        public IEnumerable<UserViewModel> GetAllUser()
        {
            var users = this._userManager.Users.ToList();

            IList<UserViewModel> userList = new List<UserViewModel>();
            foreach (var item in users)
            {
                userList.Add(UserDTO.ConvertToViewModel(item));
            }

            return userList;
        }
        public UserViewModel GetUserById(string id)
        {
            var user = this._userManager.FindById(id);
            var role = this._userManager.GetRoles(id);
            var viewModel = new UserViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                IsActive = true,
                Role = role[0]
            };

            return viewModel;
        }
    }
}
