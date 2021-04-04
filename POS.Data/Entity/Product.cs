using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Data
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int SubCategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual SubCategory SubCategories { get; set;}

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        public int OpeningStock { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        public int Stock { get; set; }

        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }





 





    }
}