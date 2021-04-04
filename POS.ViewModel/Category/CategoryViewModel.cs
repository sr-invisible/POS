using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Category
{
    public class CategoryViewModel : EntityViewModel
    {

        [RegularExpression(@"^([A-Z a-z 0-9]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Category Name is Required")]
        [Display(Name = "Category Name")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Logo")]
        public string ImagePath { get; set; }
    }
}
