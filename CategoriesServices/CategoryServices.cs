using ClothesEntities;
using ClothesDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriesServices
{
    public class CategoryServices
    {
        public void AddCategory (Category Category)
        {
            using (var Con = new Context())
            {
                Con.Categories.Add(Category);
                Con.SaveChanges();
            }
        }
       
    }
}
