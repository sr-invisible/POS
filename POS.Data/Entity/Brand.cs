using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Brand : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public virtual IList<Product> Products { get; set; }

    }
}
