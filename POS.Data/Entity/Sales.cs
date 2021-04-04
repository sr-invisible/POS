using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Sales : Entity
    {
        public string SalesInvoiceNo { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Remarks { get; set; }
        public decimal OverallDiscount { get; set; }
        public virtual ICollection<SalesDetail> SalesDetailses { get; set; }
    }
}
