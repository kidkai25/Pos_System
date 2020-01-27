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
                    UnitPrice = 500
                    //SalesId = s.SaleId
                };

            Product product2 = new Product
            {
                ProductId = 2,
                Name = "Second Product",
                CategoryId = categories[1].CategoryId,
                UnitPrice = 10000
                    //SalesId = s.SaleId
                };


        Product product3 = new Product
        {
            ProductId = 3,
            Name = "Third Product",
            CategoryId = categories[1].CategoryId,
            UnitPrice = 200000
                //SalesId = s.SaleId
            };

            Product product4 = new Product
            {
                ProductId = 4,
                Name = "Fourth Product",
                CategoryId = categories[1].CategoryId,
                UnitPrice = 300
                //SalesId = s.SaleId
            };

            Product product5 = new Product
            {
                ProductId = 5,
                Name = "Fifth Product",
                CategoryId = categories[1].CategoryId,
                //SalesId = s.SaleId
                UnitPrice = 600
            };

            Product product6 = new Product
            {
                ProductId = 6,
                Name = "Sixth Product",
                CategoryId = categories[1].CategoryId,
                //SalesId = s.SaleId
                UnitPrice = 3300
            };


            psdbcontext.Products.Add(product);
                psdbcontext.Products.Add(product2);
            psdbcontext.Products.Add(product3);
            psdbcontext.Products.Add(product4);
            psdbcontext.Products.Add(product5);
            psdbcontext.Products.Add(product6);



            ////CREATING A SAMPLE SALE//
            //Sale s = new Sale
            //{
            //    SaleId = 1,
            //    DateOfSale = DateTime.Now,
            //    AnyDiscount = true,
            //    EmployeeID = 1,
            //    InvoiceTotal = 1000,
            //    VatApplied = 10,
            //    Products = new List<Product>()
            //    {
            //        product,
            //        product2,
            //        product3,
            //        product4,
            //    }

            //};

            //psdbcontext.Sales.Add(s);


                psdbcontext.SaveChanges();


                base.Seed(psdbcontext);
        }
    }
}