using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pos_System.Models
{
    //One Product 
    //can have one category 
    //can have many sales
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public int? UnitPrice { get; set; } //keeping it int for now
        public int? AvailableQuantity { get; set; }

        public byte[] Image { get; set; }
         
        //Category
        //Fk for Category
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        //Navigation property for Sale
        public Category Category { get; set; }
        //


        //Sales
        //Fk
        [ForeignKey("Sale")]
        public int? SalesId { get; set; } //Nullable 
        //Navigation property for Sale
        public Sale Sale { get; set; }

    }
}