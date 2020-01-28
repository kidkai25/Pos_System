using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pos_System.Models
{
    //Principal End
    //One category can have many products
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }


        //Navigation Property 
        public ICollection<Product> Products { get; set; }
    }
}