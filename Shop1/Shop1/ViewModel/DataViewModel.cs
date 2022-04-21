using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop1.ViewModel
{
    public class DataViewModel
    {
        public List<ProductsViewModel> Products { get; set; }
        public List<CategoryViewModel> Category { get; set; }
    }
}