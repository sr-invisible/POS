using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.FinancialYear
{
    public class FinancialYearViewModel : EntityViewModel
    {
        [RegularExpression(@"^([A-Z a-z 0-9 -]+)*$", ErrorMessage = "Only characters, Numbers & '-' are allowed!")]
        [Required(ErrorMessage = "Financial Year Name is Required")]
        [Display(Name = "Financial Year Name")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date Start")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Date End")]
        public DateTime DateEnd { get; set; }
    }
}
