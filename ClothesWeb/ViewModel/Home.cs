using ClothesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesWeb.ViewModel
{
    public class Home
    {
        public List<Category> Categories { get; set; }
        public List<Product> products { get; set; }
        public List<Product> Speicalproducts { get; set; }
    }
}