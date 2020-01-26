using Pos_System.Models;
using Pos_System.ViewModel;
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
            BaseViewModel baseViewModel = new BaseViewModel();

            try
            {
                var posRepostiory = new PosRepository();
              
                //Checking Data a Sample Data to check ef
                var c = posRepostiory.GetCategory(1);
                // var s = posRepostiory.GetSale(1);
                var p = posRepostiory.GetProduct(1);
                var p2 = posRepostiory.GetProduct(2);

                ViewBag.Category = c.CategoryId;
                //ViewBag.Sales = s.SaleId;
                ViewBag.Product = p.ProductId;
                ViewBag.Product2 = p2.ProductId;

            }


            catch (Exception x)
            {
                throw x;
            }


            //Add ViewModel
            return View(baseViewModel);



        }


        public ActionResult LeftView(SubViewModel1 subViewModel1)
        {

            return PartialView("_LeftView");
        }

        public ActionResult RightView(SubViewModel2 subViewModel2)
        {

            return PartialView("_RightView", subViewModel2);
        }

        public ActionResult RightViewProducts(int? CategoryId, string Product = "")
        {
            var posRepostiory = new PosRepository();

            //Get Entire Products list
            var products = posRepostiory.GetProductsList();

            //Check for Category Selected
            if (CategoryId.HasValue && CategoryId != 0)
            {

                products = products.Where(p => p.CategoryId == CategoryId &&
                                p.Name.StartsWith(Product));

            }
            else
                products = products.Where(x => x.Name.StartsWith(Product));



            return PartialView("_RightViewProducts", products);
        }

    }
}