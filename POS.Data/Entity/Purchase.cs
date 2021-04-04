using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Purchase : Entity
    {
        public string InvoiceNo { get; set; }
        public int SupplierId { get; set; }
        public Decimal PaidAmount { get; set; }
        public Decimal DueAmount { get; set; }
        public string Remarks { get; set; }
        public DateTime DatePurchase { get; set; }

        public virtual IList<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
