using POS.ViewModel.Aside;
using POS.ViewModel.Section;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Custom
{
    public class AsideSectionViewModel: EntityViewModel
    {
        [Display(Name = "Section Title")]
        public string SectionTitle { get; set; }

        [Display(Name = "Option Name")]
        public string OptionName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }

        public Boolean Status { get; set; }

        public int ParentId { get; set; }
        public Boolean IsParent { get; set; }
        public Boolean HasChild { get; set; }
        public string Icon { get; set; }

        //public string ActiveLi { get; set; }

        //public List<AsideViewModel> asideViewModels { get; set; }
        //public List<SectionViewModel> sectionViewModels { get; set; }
        //public AsideViewModel asideViewModel { get; set; }
        //public SectionViewModel sectionViewModel { get; set; }
    }
}
