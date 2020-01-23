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
                var posRepostiory = new PosRepository();

                //Checking Data a Sample Data to check ef
                    var c = posRepostiory.GetCategory(1);
                    var s = posRepostiory.GetSale(1);
                    var p = posRepostiory.GetProduct(1);
                    var p2 = posRepostiory.GetProduct(2);

                    ViewBag.Category = c.CategoryId;
                    ViewBag.Sales = s.SaleId;
                    ViewBag.Product = p.ProductId;
                    ViewBag.Product2 = p2.ProductId;
                
            }


            catch (Exception x)
            {
                throw x;
            }
            return View();
            

            
        }
    }
}