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

            //Creating a list of categories

            IList<Category> categories = new List<Category> {
                                           
                                            new Category {CategoryId =1, CategoryName = "Computers" },
                                            new Category { CategoryId = 2, CategoryName = "Fruits" },
                                            new Category { CategoryId = 3, CategoryName = "Services" },
                                            new Category { CategoryId = 4, CategoryName = "Burger" },
                                            new Category { CategoryId =5, CategoryName = "Pizza" }
                                        };



            //For Later
            //Sale s = new Sale
            //{
            //    SaleId = 1,
            //    AnyDiscount = false,
            //    DateOfSale = DateTime.Now,
            //    EmployeeID = 1,
            //};

                psdbcontext.Category.AddRange(categories);
                //psdbcontext.Sales.Add(s);

                Product product = new Product
                {
                    ProductId = 1,
                    Name = "First Product",
                    CategoryId = categories[0].CategoryId,
                    //SalesId = s.SaleId
                };

                Product product2 = new Product
                {
                    ProductId = 2,
                    Name = "Second Product",
                    CategoryId = categories[1].CategoryId,
                    //SalesId = s.SaleId
                };

                psdbcontext.Products.Add(product);
                psdbcontext.Products.Add(product2);

                psdbcontext.SaveChanges();


                base.Seed(psdbcontext);
        }
    }
}