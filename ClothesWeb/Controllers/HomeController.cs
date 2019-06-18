using ClothesEntities;
using ClothesWeb.Services;
using ClothesWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesWeb.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        CategoryService CatService = new CategoryService();
        productService ProdService = new productService();
        public ActionResult Index()
        {
            Home h = new Home();
            h.Categories = CatService.GetAllCategories();
            h.products = ProdService.GetAllproducts();
            //h.Speicalproducts = 
            return View(h);
        }
        public ActionResult Speical(int CatId)
        {
            var products = ProdService.GetAllproductsByCatID(CatId);
           return PartialView(products);
        }
        public ActionResult Filter(int ID)
        {
            var products = ProdService.GetAllproductsWithPrice(ID);
            return PartialView(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}