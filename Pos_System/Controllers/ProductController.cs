using Newtonsoft.Json;
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
              
                //Checking Data: a Sample Data to check ef
                var c = posRepostiory.GetCategory(1);
                //var s = posRepostiory.GetSale(1);
                var p = posRepostiory.GetProduct(1);
                var p2 = posRepostiory.GetProduct(2);

                ViewBag.Category = c.CategoryId;
                //ViewBag.Sales = s.SaleId;
               // var x = s.Products.ToList();
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


        //public ActionResult LeftViewData()

        public ActionResult GetSale()
        {
            var posRepostiory = new PosRepository();

            Sale s = posRepostiory.GetSale(1);

            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };

            string json = JsonConvert.SerializeObject(s, Formatting.Indented, serializerSettings);

            //string json = JsonConvert.SerializeObject(s);

            return Content(json);
        }



        [HttpPost]
        public ActionResult ReceiveSale(Sale sale)
        {

            try { 
            PosRepository posRepostiory = new PosRepository();
            sale.invoiceNumber = Guid.NewGuid().ToString().Substring(0, 8); //Arbitarily putting a 8 length number


            var lastSaleID = posRepostiory.GetLastSaleID();
            sale.SaleId = lastSaleID + 1;

                foreach (var product in sale.Products)
                {

                    //Attach it. It already exists :)
                    posRepostiory.AttachProduct(product);
                }


                //Ready to save to db :)
                posRepostiory.AddSale(sale);

            var x = 0;

            posRepostiory.Save();
            }

            catch(Exception ex)
            {
                var x = 0;
            }

            //if (sale != null)
            //    return Json("Success");
            //else
            //    return Json("An Error Has occured");
            return Content("x");
        }

    }
}