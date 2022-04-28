using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop1.ViewModel
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public byte CategoryId { get; set; }
        public byte MarkId { get; set; }
        public bool NewProduct { get; set; }
    }
}