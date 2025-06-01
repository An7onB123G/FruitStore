using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Data
{
    public class FruitsContext : DbContext
    {
        public FruitsContext() : base("FruitsContext")
        {

        }

        public DbSet<FruitType> FruitTypes { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
    }
}
