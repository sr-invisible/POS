using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.PurchaseDetail
{
    public class PurchaseDetailViewModel : EntityViewModel
    {
        [Required(ErrorMessage = "Please choose a Purchase")]
        [Display(Name = "Purchase")]
        public int PurchaseId { get; set; }

        [Required(ErrorMessage = "Please choose a product")]
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Bar Code")]
        public int BarCode { get; set; }

        [Display(Name = "Bar Code Image")]
        public byte[] BarcodeImage { get; set; }

        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }

        [Display(Name = "Stock")]
        public int StockQuantity { get; set; }

        [Display(Name = "Purchase Rate")]
        public decimal PurchaseRate { get; set; }

        [Display(Name = "SaleRate")]
        public decimal SaleRate { get; set; }
        public decimal Vat { get; set; }
        public decimal Discount { get; set; }
    }
}
