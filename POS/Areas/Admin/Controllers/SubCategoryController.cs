using Microsoft.AspNet.Identity;
using POS.Service.IService;
using POS.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace POS.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            this._categoryService = categoryService;
            this._subCategoryService = subCategoryService;
        }
        public SubCategoryController()
        {

        }
        // GET: Admin/Brand
        public async Task<ActionResult> Index()
        {
            return View(await this._subCategoryService.GetAll());
        }

        // GET: Admin/Brand/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await this._subCategoryService.GetById(id));
        }

        // GET: Admin/Brand/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await this._categoryService.GetAll(), "Id", "Name").ToList();
            return View();
        }

        // POST: Admin/Brand/Create
        [HttpPost]
        public async Task<ActionResult> Create(HttpPostedFileBase file, SubCategoryViewModel viewModel)
        {
            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            viewModel.IsActive = true;
            try
            {

                if (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/gif")
                {
                    string fileName = Path.GetFileName(viewModel.Name + "-" + DateTime.Now.ToString("ddmmyyyyfff")) + Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("/Data/Images/SubCategory"), fileName);
                    file.SaveAs(path);
                    viewModel.ImagePath = "/Data/Images/SubCategory/" + fileName;
                }
                // TODO: Add insert logic here
                var result = await this._subCategoryService.Insert(viewModel);
                //if(result > 0 )
                //{

                //}
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET: Admin/Brand/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //if (id == null)
            //{
            //    return ();
            //}
            var subCategory = await this._subCategoryService.GetById(id);
            //if (file == null)
            //{
            //    return NotFound();
            //}
            ViewBag.CategoryId = new SelectList(await this._categoryService.GetAll(), "Id", "Name").ToList();
            return View(subCategory);

        }

        // POST: Admin/Brand/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, SubCategoryViewModel viewModel, HttpPostedFileBase file)
        {
            //if (id != viewModel.Id)
            //{
            //    return NotFound();
            //}
            if (file != null)
            {
                if (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/gif")
                {
                    string fileName = Path.GetFileName(viewModel.Name + "-" + DateTime.Now.ToString("ddmmyyyyfff")) + Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("/Data/Images/SubCategory"), fileName);
                    file.SaveAs(path);
                    viewModel.ImagePath = "/Data/Images/SubCategory/" + fileName;
                }
            }
            else
            {
                viewModel.ImagePath = "oldPath";
            }

            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            viewModel.IsActive = true;
            try
            {
                await this._subCategoryService.Update(viewModel);
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
            return this._subCategoryService.GetAll().Result.Any(x => x.Id == id);
        }
        // GET: Admin/Brand/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            var subCategory = await this._subCategoryService.GetById(id);
            //if (file == null)
            //{
            //    return NotFound();
            //}
            return View(subCategory);
        }

        // POST: Admin/Brand/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, SubCategoryViewModel viewModel)
        {
            await this._subCategoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<ActionResult> UpdateIsActiveById(SubCategoryViewModel viewModel)
        {
            viewModel.Name = "oldName";
            viewModel.Description = "oldDescription";
            viewModel.ImagePath = "oldPath";
            viewModel.CategoryId = 0;  // old categtory id
            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            try
            {
                // TODO: Add insert logic here
                await this._subCategoryService.Update(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}