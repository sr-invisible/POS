using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Purchase
{
    public class PurchaseViewModel : EntityViewModel
    {
        [Required(ErrorMessage = "Please enter an invoice number")]
        [Display(Name = "Invoice No")]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        [Required(ErrorMessage = "Please select a date")]
        [Display(Name = "Date Purchase")]
        public DateTime DatePurchase { get; set; }

        [Required(ErrorMessage = "Please choose a supplier")]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [Display(Name = "Paid Amount")]
        public decimal PaidAmount { get; set; }

        [Display(Name = "Due Amount")]
        public decimal DueAmount { get; set; }
    }
}
