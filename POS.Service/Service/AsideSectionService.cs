using POS.Service.IService;
using POS.ViewModel.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Service
{
    public class AsideSectionService : IAsideSectionService
    {
        private readonly IAsideService _asideService;
        private readonly ISectionService _sectionService;
        public AsideSectionService(IAsideService asideService, ISectionService sectionService)
        {
            this._asideService = asideService;
            this._sectionService = sectionService;
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
    }
}
