using FruitStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Controllers
{
    public class FruitTypeControllers
    {
        private FruitsContext fruitDbContext = new FruitsContext();

        public List<Fruit> GetAllFruits()
        {
            return fruitDbContext.Fruits.ToList();
        }

        public List<FruitType> GetAllFruitTypes()
        {
            return fruitDbContext.FruitTypes.ToList();
        }

        public string GetFruitById(int id)
        {
            return fruitDbContext.Fruits.Find(id).Name;
        }
    }
}
