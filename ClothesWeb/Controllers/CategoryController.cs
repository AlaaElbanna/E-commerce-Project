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

    public class CategoryController : Controller
    {
        CategoryService CatService = new CategoryService();
        productService productservice = new productService();
        public ActionResult index()
        {

            return View();
        }
        public ActionResult CategoryTable(string Search)
        {
            var categories = CatService.GetAllCategories();
            foreach (var item in categories)
            {
                item.Products = productservice.GetAllproductsByCatID(item.ID).ToList();
            }

            if (Search != null)
                categories = categories.Where(p => p.Name != null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
            return PartialView(categories);
        }
        public ActionResult ShowProducts(int ID)
        {
            var Products= productservice.GetAllproductsByCatID(ID);
            return View(Products);
        }
        // GET: Category
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            CatService.AddCategory(category);
            return RedirectToAction("CategoryTable");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Category cat= CatService.GetCategoryById(ID);
            return PartialView(cat);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            CatService.EditCategory(category);
            return RedirectToAction("CategoryTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            CatService.DeleteCategory(ID);
            return RedirectToAction("index");
        }
    }
}