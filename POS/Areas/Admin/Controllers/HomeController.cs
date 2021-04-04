using POS.Service.IService;
using POS.ViewModel.Custom;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace POS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class HomeController : Controller
    {
        private readonly ISectionService _sectionService;
        private readonly IAsideService _asideService;
        private readonly IAsideSectionService _asideSectionService;
        public HomeController(ISectionService sectionManager, IAsideService asideManager, IAsideSectionService asideSectionService)
        {
            this._sectionService = sectionManager;
            this._asideService = asideManager;
            this._asideSectionService = asideSectionService;
        }
        public HomeController() { }

        // GET: Admin/Home
        public ActionResult Index()
        {
            //Session["AsideSections"] = GetAsideSection();
            ViewData["AsideSections"] = this._asideSectionService.GetAsideSection();

            return View();
        }

        //public IEnumerable<AsideSectionViewModel> GetAsideSection()
        //{
        //    var Sections = this._sectionService.GetAll();
        //    var Asides = this._asideService.GetAll();
        //    var AsideSectionList = (from a in Asides
        //                            join s in Sections on a.SectionId equals s.Id
        //                            select new AsideSectionViewModel { Id = a.Id, SectionTitle = s.SectionTitle, Area = a.Area, OptionName = a.OptionName, Controller = a.Controller, 
        //                                Action = a.Action, IsParent = a.IsParent, ParentId = a.ParentId, HasChild = a.HasChild, Icon = a.Icon, IsActive = a.IsActive }
        //                            ).ToList();
        //    return AsideSectionList;
        //}

        // GET: Admin/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Home/Edit/5
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

        // GET: Admin/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Home/Delete/5
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
        public JsonResult AsideSection()
        {
            var Sections = this._sectionService.GetAll();
            var Asides = this._asideService.GetAll();
            var AsideSectionList = (from a in Asides
                                    join s in Sections on a.SectionId equals s.Id
                                    select new { a.Id, s.SectionTitle, a.Area, a.OptionName, a.Controller, a.Action, a.IsParent, a.ParentId, a.HasChild, a.IsActive }
                                    ).ToList();
            return Json(AsideSectionList, JsonRequestBehavior.AllowGet);
        }
    }
}
