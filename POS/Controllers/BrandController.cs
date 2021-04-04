using Microsoft.AspNet.Identity;
using POS.Service.IService;
using POS.ViewModel.Brand;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService BrandService)
        {
            this._brandService = BrandService;
        }
        public BrandController()
        {

        }
        // GET: Admin/Brand
        public async Task<ActionResult> Index()
        {
            return View(await this._brandService.GetAll());
        }

        // GET: Admin/Brand/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await this._brandService.GetById(id));
        }

        // GET: Admin/Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brand/Create
        [HttpPost]
        public async Task<ActionResult> Create(HttpPostedFileBase file, BrandViewModel viewModel)
        {
            if (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/gif")
            {
                string fileName = Path.GetFileName(viewModel.Name + "-" + DateTime.Now.ToString("ddmmyyyyfff")) + Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("/Data/Images/Brand"), fileName);
                file.SaveAs(path);
                viewModel.ImagePath = "/Data/Images/Brand/" + fileName;
            }

            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            viewModel.IsActive = true;
            try
            {
                // TODO: Add insert logic here
                await this._brandService.Insert(viewModel);
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
            var brand = await this._brandService.GetById(id);
            //if (file == null)
            //{
            //    return NotFound();
            //}

            return View(brand);

        }

        // POST: Admin/Brand/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, BrandViewModel viewModel, HttpPostedFileBase file)
        {
            //if (id != viewModel.Id)
            //{
            //    return NotFound();
            //}
            if(file !=null)
            {
                if (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/gif")
                {
                    string fileName = Path.GetFileName(viewModel.Name + "-" + DateTime.Now.ToString("ddmmyyyyfff")) + Path.GetExtension(file.FileName);
                    string path = Path.Combine(Server.MapPath("/Data/Images/Brand"), fileName);
                    file.SaveAs(path);
                    viewModel.ImagePath = "/Data/Images/Brand/" + fileName;
                }
            }

            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            viewModel.IsActive = true;
            try
            {
                await this._brandService.Update(viewModel);
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

        private  bool FileExists(int id)
        {
            return  this._brandService.GetAll().Result.Any(x => x.Id == id);
        }
        // GET: Admin/Brand/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            var brand = await this._brandService.GetById(id);
            //if (file == null)
            //{
            //    return NotFound();
            //}
            return View(brand);
        }

        // POST: Admin/Brand/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, BrandViewModel viewModel)
        {
            await this._brandService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}