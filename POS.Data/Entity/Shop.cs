using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Shop : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string Phone { get; set; }

        public int FinancialYearId { get; set; }
        [ForeignKey("FinancialYearId")]
        public virtual FinancialYear FinancialYear { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
