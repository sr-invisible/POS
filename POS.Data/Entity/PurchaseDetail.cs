using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class PurchaseDetail : Entity
    {
        public string Name { get; set; }
        public int BarCode { get; set; }
        public byte[] BarcodeImage { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int StockQuantity { get; set; }
        public decimal PurchaseRate { get; set; }
        public decimal SaleRate { get; set; }
        public decimal Vat { get; set; }
        public decimal Discount { get; set; }
        public int PurchaseId { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
