using Microsoft.AspNet.Identity;
using POS.Service.IService;
using POS.ViewModel.FinancialYear;
using POS.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace POS.Areas.Admin.Controllers
{
    public class FinancialYearController : Controller
    {
        private readonly IFinancialYearService _financialYearService;
        public FinancialYearController(IFinancialYearService financialYearService)
        {
            this._financialYearService = financialYearService;
        }
        public FinancialYearController()
        {

        }
        // GET: Admin/FinancialYear
        public async Task<ActionResult> Index()
        {
            return View(await this._financialYearService.GetAll());
        }

        // GET: Admin/FinancialYear/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await this._financialYearService.GetById(id));
        }

        // GET: Admin/FinancialYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FinancialYear/Create
        [HttpPost]
        public async Task<ActionResult> Create(FinancialYearViewModel viewModel)
        {
            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            viewModel.IsActive = true;
            try
            {
                // TODO: Add insert logic here
                var result = await this._financialYearService.Insert(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // GET: Admin/FinancialYear/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //if (id == null)
            //{
            //    return ();
            //}
            var financialYear = await this._financialYearService.GetById(id);
            //if (file == null)
            //{
            //    return NotFound();
            //}

            return View(financialYear);

        }

        // POST: Admin/FinancialYear/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FinancialYearViewModel viewModel)
        {
            //if (id != viewModel.Id)
            //{
            //    return NotFound();
            //}

            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            try
            {
                await this._financialYearService.Update(viewModel);
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
            return this._financialYearService.GetAll().Result.Any(x => x.Id == id);
        }
        // GET: Admin/FinancialYear/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            var financialYear = await this._financialYearService.GetById(id);
            //if (file == null)
            //{
            //    return NotFound();
            //}
            return View(financialYear);
        }

        // POST: Admin/FinancialYear/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FinancialYearViewModel viewModel)
        {
            await this._financialYearService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<ActionResult> UpdateIsActiveById(FinancialYearViewModel viewModel)
        {
            viewModel.Name = "oldName";
            viewModel.Description = "oldDescription";
            viewModel.DateStart = DateTime.Now;
            viewModel.DateEnd = DateTime.Now;
            viewModel.DateCreated = DateTime.Now;
            viewModel.DateUpdated = DateTime.Now;
            viewModel.CreatedByUserId = User.Identity.GetUserId();
            viewModel.UpdatedByUserId = User.Identity.GetUserId();
            try
            {
                // TODO: Add insert logic here
                await this._financialYearService.Update(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}