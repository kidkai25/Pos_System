using Pos_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pos_System.ViewModel
{

    //Right Half of Main Screen
    public class SubViewModel2
    {
        //Creating Category
        public SubViewModel2()
        {
            PosRepository pr = new PosRepository();

            //Initializing properties
            this.Categories = pr.GetCategoryList();
            this.Products = pr.GetProductsList();

        }
        public IEnumerable<Category> Categories { get; }

        public IEnumerable<Product> Products { get; }

        //Creating Products
    }
}