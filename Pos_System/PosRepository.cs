using Pos_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pos_System
{

    //Putting common methods here 
    public class PosRepository
    {
        private ProductsDbContext pdb = new ProductsDbContext();


        public Sale GetSale(int id)
        {
            return pdb.Sales.SingleOrDefault(s => s.SaleId == id);
        }

        public Product GetProduct(int id)
        {
            return pdb.Products.SingleOrDefault(p => p.ProductId == id);
        }

        public Category GetCategory(int id)
        {
            return pdb.Category.SingleOrDefault(c => c.CategoryId == id);
        }


        public IEnumerable<Category> GetCategoryList()
        {
            return pdb.Category.ToList();
        }

        public IEnumerable<Product> GetProductsList()
        {
            return pdb.Products.ToList();
        }

        public IQueryable<Product> MaxPriceProduct()
        {
            var maxPrice = pdb.Products.Max(p => p.UnitPrice);
            return pdb.Products.Where(p =>  p.UnitPrice == maxPrice);
        }

        public IQueryable<int?> GetQuantity(int productId)
        {
            return from product in pdb.Products
                   where product.ProductId == productId
                   select product.AvailableQuantity;
        }


        public void AddSale(Sale s)
        {
            pdb.Sales.Add(s);
        }
        public int GetLastSaleID()
        {
            return pdb.Sales.OrderByDescending(x => x.SaleId)
                            .Select(x => x.SaleId)                        
                            .FirstOrDefault();
        }

        public void Save()
        {
            pdb.SaveChanges();
        }

        public void AttachProduct(Product p)
        {
            pdb.Products.Attach(p);
        }
        
    }
}