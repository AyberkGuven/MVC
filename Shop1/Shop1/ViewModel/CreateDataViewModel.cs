using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop1.ViewModel
{
    public class CreateDataViewModel
    {
        public CreateViewModel Product { get; set; }
        public List<CategoryViewModel> Category { get; set; }
        public List<MarkViewModel> Mark { get; set; }
    }
}