using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Supplier
{
    public class SupplierViewModel : EntityViewModel
    {
        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Supplier name is required")]
        [Display(Name = "Supplier Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [RegularExpression(@"^([0-9]+)*$", ErrorMessage = "Only Numbers are allowed!")]
        [Required(ErrorMessage = "Phone name is required")]
        [Display(Name = "Phone Number")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please Input Valid Email Address")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100)]
        public string Address { get; set; }
    }
}
