using ClothesDatabase;
using ClothesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesWeb.Services
{
    public class CategoryService
    {
        public void AddCategory(Category Category)
        {
            using (var Con = new Context())
            {
                Con.Categories.Add(Category);
                Con.SaveChanges();
            }
        }
        public List<Category> GetAllCategories()
        {
            using (var Con = new Context())
            {
                return Con.Categories.ToList() ;
             }
        }
        public Category GetCategoryById(int Id)
        {
            using (var Con = new Context())
            {
                return Con.Categories.First(cat => cat.ID == Id);
            }
        }

        public void EditCategory(Category category)
        {
            using (var Con = new Context())
            {
                var cate = Con.Categories.First(cat => cat.ID == category.ID);
                cate.Name = category.Name;
                cate.Description = category.Description;
                if(category.ImageURL!=null)
                    cate.ImageURL = category.ImageURL;
                Con.SaveChanges();
            }
        }
        public void DeleteCategory(int ID)
        {
            using (var Con = new Context())
            {
                var cate = Con.Categories.First(cat => cat.ID == ID);
                Con.Categories.Remove(cate);
                Con.SaveChanges();
            }
        }
    }
}