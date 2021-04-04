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
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        public RoleController()
        {

        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            var roles = this._roleManager.Roles.ToList();
            return View(roles);
        }

        // GET: Admin/Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Role/Create
        [HttpPost]
        public ActionResult Create(RoleViewModel viewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (!this._roleManager.RoleExists(viewModel.Name))
                {
                    var result = this._roleManager.CreateAsync(new IdentityRole(viewModel.Name));//Add new Role
                   return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Role/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
