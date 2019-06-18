using ClothesDatabase;
using ClothesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesWeb.Services
{
    public class productService
    {
        public void Addproduct(Product product)
        {
            using (var Con = new Context())
            {
                Con.products.Add(product);
                Con.SaveChanges();
            }
        }
        public List<Product> GetAllproducts()
        {
            using (var Con = new Context())
            {
                return Con.products.ToList();
            }
        }
        public List<Product> GetAllproductsWithPrice(int Price)
        {
            using (var Con = new Context())
            {
                return Con.products.Where(p=>p.Price>=Price).ToList();
            }
        }
        public List<Product> GetAllproducts(List<int>Ids)
        {
            using (var Con = new Context())
            {
                return Con.products.Where(x=>Ids.Contains(x.ID)).ToList();
            }
        }
        public List<Product> GetAllproductsByCatID(int CatId)
        {
            using (var Con = new Context())
            {
                return Con.products.Where(p=>p.Cat_Id== CatId).ToList();
            }
        }
        public Product GetproductById(int Id)
        {
            using (var Con = new Context())
            {
                return Con.products.First(cat => cat.ID == Id);
            }
        }

        public void Editproduct(Product product)
        {
            using (var Con = new Context())
            {
                var prod = Con.products.First(cat => cat.ID == product.ID);
                prod.Name = product.Name;
                prod.Description = product.Description;
                prod.Price = product.Price;
                if (product.ImageURL != null)
                    prod.ImageURL = product.ImageURL;
                Con.SaveChanges();
            }
        }
        public void Deleteproduct(int ID)
        {
            using (var Con = new Context())
            {
                var prod = Con.products.First(cat => cat.ID == ID);
                Con.products.Remove(prod);
                Con.SaveChanges();
            }
        }
    }
}