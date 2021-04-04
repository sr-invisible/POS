using Microsoft.AspNet.Identity;
using POS.Service.IService;
using POS.ViewModel.Aside;
using POS.ViewModel.Section;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class AsideController : Controller
    {
        private readonly IAsideService _asideService;
        private readonly ISectionService _sectionService;

        public AsideController(IAsideService asideManager, ISectionService sectionManager)
        {
            this._asideService = asideManager;
            this._sectionService = sectionManager;
        }
        public AsideController()
        {

        }
        // GET: Admin/Aside
        public ActionResult Index()
        {
            return View(this._asideService.GetAll());
        }

        // GET: Admin/Aside/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }  

        // GET: Admin/Aside/Create
        public ActionResult Create()
        {
            ViewBag.SectionId = new SelectList(this._sectionService.GetAll(), "Id", "SectionTitle").ToList();

            var areaName = Directory.EnumerateDirectories(Server.MapPath("/Areas")).Select(f => Path.GetFileName(f)).ToList();
            //areaName.Add("None");
            ViewBag.Areas = new SelectList(areaName).ToList();
            return View();
        }

        // POST: Admin/Aside/Create
        [HttpPost]
        public ActionResult Create(AsideViewModel viewModel)
        {

            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            viewModel.IsActive = true;
            try
            {
                // TODO: Add insert logic here
                this._asideService.Insert(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        // GET: Admin/Aside/Edit/5
        public ActionResult Edit(int id)
        {
            //if (id == null)
            //{
            //    return ();
            //}
            var aside = this._asideService.GetById(id);
            //if (file == null)
            //{
            //    return NotFound();
            //}
            //ViewBag.ServerId = new SelectList(this._sectionService.GetAll(), "SectionTitle", "SectionTitle", aside.SectionId);

            ViewBag.SectionId = new SelectList(this._sectionService.GetAll(), "Id", "SectionTitle").ToList();

            var areaName = Directory.EnumerateDirectories(Server.MapPath("/Areas")).Select(f => Path.GetFileName(f)).ToList();
            //areaName.Add("None");
            ViewBag.Areas = new SelectList(areaName).ToList();
            return View(aside);
            
        }
        public JsonResult GetDataForEdit(int id)
        {
            var aside = this._asideService.GetById(id);

            return Json(aside, JsonRequestBehavior.AllowGet);
        }

            // POST: Admin/Aside/Edit/5
            [HttpPost]
        public ActionResult Edit(int id, AsideViewModel viewModel)
        {
            //if (id != viewModel.Id)
            //{
            //    return NotFound();
            //}

            try
            {
                 this._asideService.Update(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileExists(viewModel.Id))
                {
                    //return NotFound();
                }
                else
                {
                    throw;
                }
            }
           

            return View(viewModel);
        }

        private bool FileExists(int id)
        {
            return this._asideService.GetAll().Any(x => x.Id == id);
        }
        // GET: Admin/Aside/Delete/5
        public ActionResult Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            var aside = this._asideService.GetById(id);
            //if (file == null)
            //{
            //    return NotFound();
            //}
            return View(aside);
        }

        // POST: Admin/Aside/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AsideViewModel viewModel)
        {
             this._asideService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public JsonResult GetUniqueOptionName(string area, string optionName)
        {
            var Asides = this._asideService.GetAll();
            var asideOptionName = from s in Asides
                         where s.OptionName == optionName && s.Area == area
                         select s.OptionName;
            return Json(asideOptionName, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUniqueSectionTitle(string sectionTitle)
        {
            var Sections = this._sectionService.GetAll();
            var sectionSectionTitle = from s in Sections
                                  where s.SectionTitle == sectionTitle
                                  select s.SectionTitle;
            return Json(sectionSectionTitle, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void CreateSection(SectionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.DateCreated = DateTime.Now;
                viewModel.DateUpdated = DateTime.Now;
                viewModel.CreatedByUserId = User.Identity.GetUserId();
                viewModel.UpdatedByUserId = User.Identity.GetUserId();
                viewModel.IsActive = true;
                try
                {
                    this._sectionService.Insert(viewModel);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public JsonResult GetAllSection()
        {
            var data = this._sectionService.GetAll();
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllArea()
        {
            var areaName = Directory.EnumerateDirectories(Server.MapPath("/Areas")).Select( f => Path.GetFileName(f));
            return Json(areaName, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllControllerByArea(string area)
        {
            if( area == "Admin")
            {
                var controllerName = Directory.EnumerateFiles(Server.MapPath("/Areas/" + area + "/Controllers")).Select(f => Path.GetFileNameWithoutExtension(f.Replace("Controller", "")));
                return Json(controllerName, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var controllerName = Directory.EnumerateFiles(Server.MapPath("/Controllers")).Select(f => Path.GetFileNameWithoutExtension(f.Replace("Controller", "")));
                return Json(controllerName, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllActionByControllerAndArea(string controllerName, string area)
        {
            if (controllerName == "None")
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

            if (area == "Admin")
            {
                var actionName = Directory.EnumerateFiles(Server.MapPath("/Areas/" + area + "/Views/" + controllerName)).Select(f => Path.GetFileNameWithoutExtension(f));
                return Json(actionName, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var actionName = Directory.EnumerateFiles(Server.MapPath("/Views/" + controllerName)).Select(f => Path.GetFileNameWithoutExtension(f));
                return Json(actionName, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllParents()
        {
            var data = this._asideService.GetAllParentsByParentIdAndIsParent();
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        

    }
}
