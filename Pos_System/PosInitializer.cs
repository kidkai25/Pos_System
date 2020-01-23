using Pos_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pos_System
{
    public class PosInitializer : DropCreateDatabaseAlways<ProductsDbContext>
    {
        protected override void Seed(ProductsDbContext psdbcontext)
        {
                //Moving Sample Data here          
              
                Category c = new Category { CategoryId = 1, CategoryName = "First" };
                Sale s = new Sale
                {
                    SaleId = 1,
                    AnyDiscount = false,
                    DateOfSale = DateTime.Now,
                    EmployeeID = 1,
                };

                psdbcontext.Category.Add(c);
                psdbcontext.Sales.Add(s);

                Product product = new Product
                {
                    ProductId = 1,
                    Name = "First Product",
                    CategoryId = c.CategoryId,
                    SalesId = s.SaleId
                };

            Product product2 = new Product
            {
                ProductId = 2,
                Name = "Second Product",
                CategoryId = c.CategoryId,
                SalesId = s.SaleId
            };

            psdbcontext.Products.Add(product);
            psdbcontext.Products.Add(product2);

                psdbcontext.SaveChanges();


                base.Seed(psdbcontext);
        }
    }
}