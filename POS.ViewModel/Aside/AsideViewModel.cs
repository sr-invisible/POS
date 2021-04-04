using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Aside
{
    public class AsideViewModel : EntityViewModel
    {
        [Display(Name = "Section Title")]
        public int SectionId { get; set; }

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

    }

}
