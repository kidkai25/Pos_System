using Pos_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pos_System.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            try
            {
                using (var psdbcontext = new ProductsDbContext())
                {
                    //Creating a Sample Data to check ef
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

                    psdbcontext.SaveChanges();


                    //Product product = new Product
                    //{
                    //    ProductId = 1,
                    //    Name = "First Product",
                    //    CategoryId = c.CategoryId,
                    //    SalesId = s.SaleId
                    //};

                    ViewBag.Category = c.CategoryId;
                    ViewBag.Sales = s.SaleId;


                }
            }
            catch (Exception x)
            {
                var d = 0;
            }
            return View();
            

            
        }
    }
}