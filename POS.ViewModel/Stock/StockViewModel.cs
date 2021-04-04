using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Stock
{
    public class StockViewModel : EntityViewModel
    {
        public decimal Price { get; set; }
        public int Sale { get; set; }
        public int Purchase { get; set; }

        [Display(Name = "Available Stock")]
        public int AvailableStock { get; set; }
        public decimal SellValue { get; set; }
    }
}
