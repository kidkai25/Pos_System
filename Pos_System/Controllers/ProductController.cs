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
                    //Checking Data a Sample Data to check ef
                    var c = psdbcontext.Category.Find(1);
                    var s = psdbcontext.Sales.Find(1);
                    var p = psdbcontext.Products.Find(1);

               
                    ViewBag.Category = c.CategoryId;
                    ViewBag.Sales = s.SaleId;
                    ViewBag.Product = p.ProductId;


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