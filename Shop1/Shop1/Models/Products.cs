using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop1.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public byte CategoryId { get; set; }
        public Category Category { get; set; }
        public byte MarkId { get; set; }
        public Mark Mark { get; set; }
        public bool NewProduct { get; set; }
    }
}