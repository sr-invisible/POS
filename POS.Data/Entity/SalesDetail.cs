using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class SalesDetail : Entity
    {
        public int BarCode { get; set; }
        public int Quantity { get; set; }
        public decimal SalesRate { get; set; }
        public decimal Vat { get; set; }
        public decimal LineDiscount { get; set; }
        public int SalesId { get; set; }
        [ForeignKey("SalesId")]
        public virtual Sales Sales { get; set; }

        public int ProductId { get; set; }

    }
}
