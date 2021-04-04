using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Stock : Entity
    {
        
        public decimal Price { get; set; }
        public int Sale { get; set; }
        public int Purchase { get; set; }
        public int AvailableStock { get; set; }
        public decimal SellValue { get; set; }

    }
}
