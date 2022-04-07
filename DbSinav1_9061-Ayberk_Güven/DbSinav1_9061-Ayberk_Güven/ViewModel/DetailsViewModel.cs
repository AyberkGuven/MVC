using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbSinav1_9061_Ayberk_Güven.ViewModel
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Direction { get; set; }
        public string Genders { get; set; }
        public int DetailsId { get; set; }
        public bool Delete { get; set; }
    }
}