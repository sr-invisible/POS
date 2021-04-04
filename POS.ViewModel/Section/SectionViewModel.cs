using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Section
{
    public class SectionViewModel : EntityViewModel
    {
        [Display(Name ="Section Title")]
        public string SectionTitle { get; set; }
        public string Status { get; internal set; }
    }
}
