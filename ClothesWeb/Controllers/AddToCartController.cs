using ClothesEntities;
using ClothesWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesWeb.Controllers
{
    [Authorize]

    public class AddToCartController : Controller
    {
        // GET: AddToCart
        public ActionResult Index()
        {
            productService proService = new productService();
            CategoryService cateService = new CategoryService();
            var pro = Request.Cookies["Products"];
            List<Product> products = null;
            if (pro!=null)
            {
                var IDs = pro.Value;
                var ProIds = IDs.Split('-').Select(x => int.Parse(x)).ToList();
                products = proService.GetAllproducts(ProIds);
                foreach (var item in products)
                {
                    item.Category = cateService.GetCategoryById(item.Cat_Id);
                }
            }
            return View(products);
        }
    }
}