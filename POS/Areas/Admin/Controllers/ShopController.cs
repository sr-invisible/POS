using Microsoft.AspNet.Identity;
using POS.Service.IService;
using POS.ViewModel.Shop;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace POS.Areas.Admin.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        private readonly IFinancialYearService _financialYearService;
        public ShopController(IShopService shopService, IFinancialYearService financialYearService)
        {
            this._shopService = shopService;
            this._financialYearService = financialYearService;
        }
        public ShopController()
        {

        }
        // GET: Admin/Brand
        public async Task<ActionResult> Index()
        {
            return View(await this._shopService.GetAll());
        }

        // GET: Admin/Brand/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await this._shopService.GetById(id));
        }

        // GET: Admin/Brand/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.FinancialYearId = new SelectList(await this._financialYearService.GetAll(), "Id", "Name").ToList();
            return View();
        }

        // POST: Admin/Brand/Create
        [HttpPost]
        public async Task<ActionResult> Create(HttpPostedFileBase file, ShopViewModel viewModel)
        {
            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            viewModel.IsActive = true;
            try
            {
                // TODO: Add insert logic here
                var result = await this._shopService.Insert(viewModel);
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
            var shop = await this._shopService.GetById(id);
            //if (file == null)
            //{
            //    return NotFound();
            //}
            ViewBag.FinancialYearId = new SelectList(await this._financialYearService.GetAll(), "Id", "Name").ToList();
            return View(shop);

        }

        // POST: Admin/Brand/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ShopViewModel viewModel, HttpPostedFileBase file)
        {
            //if (id != viewModel.Id)
            //{
            //    return NotFound();
            //}
            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            viewModel.IsActive = true;
            try
            {
                await this._shopService.Update(viewModel);
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
            return this._shopService.GetAll().Result.Any(x => x.Id == id);
        }
        // GET: Admin/Brand/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            var shop = await this._shopService.GetById(id);
            //if (file == null)
            //{
            //    return NotFound();
            //}
            return View(shop);
        }

        // POST: Admin/Brand/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, ShopViewModel viewModel)
        {
            await this._shopService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<ActionResult> UpdateIsActiveById(ShopViewModel viewModel)
        {
            viewModel.Name = "oldName";
            viewModel.Email = "oldEmail";
            viewModel.Address = "oldAdress";
            viewModel.WebAddress = "oldWebAdress";
            viewModel.Phone = "oldPHone";
            viewModel.FinancialYearId = 0; //old financial year Id
            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            try
            {
                // TODO: Add insert logic here
                await this._shopService.Update(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}