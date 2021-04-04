using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Brand
{
    public class BrandViewModel : EntityViewModel
    {
        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Brand Name is Required")]
        [Display(Name = "Brand Name")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Logo")]
        public string ImagePath { get; set; }


    }
}
