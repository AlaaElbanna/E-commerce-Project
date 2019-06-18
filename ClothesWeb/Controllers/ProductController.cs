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

    public class ProductController : Controller
    {
        productService prodService = new productService();
        CategoryService cateService = new CategoryService();
        // GET: Product
        public ActionResult index()
        {
            return View();
        }
        public ActionResult ProducTable(string Search)
        {
            var products = prodService.GetAllproducts();
            foreach (var item in products)
            {
                item.Category = cateService.GetCategoryById(item.Cat_Id);
            }
            if (Search !=null)
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
            return PartialView(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CategoryService cat = new CategoryService();
            var categories = cat.GetAllCategories();
            return PartialView(categories);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            prodService.Addproduct(product);
            return RedirectToAction("ProducTable");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Product pro = prodService.GetproductById(ID);
            return PartialView(pro);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            prodService.Editproduct(product);
            return RedirectToAction("ProducTable");
        }
       
        [HttpPost]
        public ActionResult DeleteProd(int ID)
        {
            prodService.Deleteproduct(ID);
            return RedirectToAction("ProducTable");
        }
    }
}