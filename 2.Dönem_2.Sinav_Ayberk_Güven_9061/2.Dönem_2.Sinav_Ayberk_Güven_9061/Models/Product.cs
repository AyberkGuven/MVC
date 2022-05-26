using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2.Dönem_2.Sinav_Ayberk_Güven_9061.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePatch { get; set; }
        public decimal Price { get; set; }
        public bool NewProduct { get; set; }
        public string explanation { get; set; }
        public byte CategoryId { get; set; }
        public int ImageId { get; set; }
        public Category Category { get; set; }

    }
}