using POS.ViewModel.Brand;
using POS.ViewModel.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Product
{
    public class ProductViewModel : EntityViewModel
    {
        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Product Name is Required")]
        [Display(Name = "Product Name")]
        [StringLength(150)]
        public string Name { get; set; }
        public string Code { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Sub Category")]
        public int SubCategoryId { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        [Display(Name = "Opening Stock")]
        public int OpeningStock { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        [RegularExpression(@"^([0-9 ]+)*$", ErrorMessage = "Only numbers are allowed!")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Display(Name = "Shop")]
        public int ShopId { get; set; }
        
    }
}
