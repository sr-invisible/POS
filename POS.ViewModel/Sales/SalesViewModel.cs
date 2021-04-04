using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Sales
{
    public class SalesViewModel : EntityViewModel
    {
        [Display(Name = "Sales Invoice No")]
        public string SalesInvoiceNo { get; set; }

        [Required(ErrorMessage = "Please choose a Customer")]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public string Remarks { get; set; }

        [Display(Name = "Overall Discount")]
        public decimal OverallDiscount { get; set; }
    }
}
