using POS.Service.IService;
using POS.ViewModel.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISectionService _sectionService;
        private readonly IAsideService _asideService;
        public HomeController()
        {

        }
        public HomeController(ISectionService sectionService, IAsideService asideService)
        {
            this._sectionService = sectionService;
            this._asideService = asideService;
        }
        public ActionResult Index()
        {
            //Session["AsideSections"] = GetAsideSection();
            //ViewData["AsideSections"] = GetAsideSection();
            return View();
        }
        public IEnumerable<AsideSectionViewModel> GetAsideSection()
        {
            var Sections = this._sectionService.GetAll();
            var Asides = this._asideService.GetAll();
            var AsideSectionList = (from a in Asides
                                    join s in Sections on a.SectionId equals s.Id
                                    select new AsideSectionViewModel
                                    {
                                        Id = a.Id,
                                        SectionTitle = s.SectionTitle,
                                        Area = a.Area,
                                        OptionName = a.OptionName,
                                        Controller = a.Controller,
                                        Action = a.Action,
                                        IsParent = a.IsParent,
                                        ParentId = a.ParentId,
                                        HasChild = a.HasChild,
                                        Icon = a.Icon,
                                        IsActive = a.IsActive
                                    }
                                    ).ToList();
            return AsideSectionList;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}