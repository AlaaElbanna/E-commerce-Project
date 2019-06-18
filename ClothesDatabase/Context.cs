using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesEntities;

namespace ClothesDatabase
{
    public class Context : DbContext, IDisposable
    {
        public Context() : base("Data Source=.;Initial Catalog=ClothesDatabase;Integrated Security=True")
        { }
       public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
