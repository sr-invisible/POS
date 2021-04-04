using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Logo")]
        public string ImagePath { get; set; }

        public virtual IList<Product> Products { get; set; }
        public virtual IList<SubCategory> SubCategories { get; set; }
    }
}
