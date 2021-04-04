using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Customer
{
    public class CustomerViewModel : EntityViewModel
    {
        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Customer Name is Required")]
        [Display(Name = "Customer Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [RegularExpression(@"^([0-9]+)*$", ErrorMessage = "Only Numbers are allowed!")]
        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [StringLength(20)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
