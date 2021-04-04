using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Shop
{
    public class ShopViewModel : EntityViewModel
    {
        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Shop name is required")]
        [Display(Name = "Shop Name")]
        [StringLength(200)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please Input Valid Email Address")]
        [StringLength(100)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        [StringLength(300)]
        public string Address { get; set; }

        

        [Display(Name = "Web Address")]
        [StringLength(100)]
        public string WebAddress { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please choose a financial year")]
        [Display(Name = "Financial Year")]
        public int FinancialYearId { get; set; }
    }
}
