using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pos_System.Models
{
    //Principal end
    //One sale can have many products
    public class Sale
    {
        public int SaleId { get; set; }

        public int EmployeeID { get; set;}

        public DateTime DateOfSale { get; set; }


        public bool AnyDiscount { get; set; }

        public decimal? VatApplied { get; set; }

        public decimal? InvoiceTotal { get; set; }


        //Many Products
        public ICollection<Product> Products { get; set; }


    }
}