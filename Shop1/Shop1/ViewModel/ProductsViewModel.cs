using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop1.ViewModel
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
        public string MarkName { get; set; }
        public bool NewProduct { get; set; }
    }
}