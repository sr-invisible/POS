using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.SalesDetail
{
    public class SalesDetailViewModel : EntityViewModel
    {
        [Required(ErrorMessage = "Please choose a Sales")]
        [Display(Name = "Sales")]
        public int SalesId { get; set; }

        [Required(ErrorMessage = "Please choose a product")]
        [Display(Name ="Product")]
        public int ProductId { get; set; }
        [Display(Name = "Bar Code")]
        public int BarCode { get; set; }
        public int Quantity { get; set; }

        [Display(Name = "Sales Rate")]
        public decimal SalesRate { get; set; }
        public decimal Vat { get; set; }

        [Display(Name = "Line Discount")]
        public decimal LineDiscount { get; set; }
    }
}
