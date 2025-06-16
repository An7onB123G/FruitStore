using FruitStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Controllers
{
    public class FruitController
    {
        private FruitsContext fruitDbContext = new FruitsContext();

        public Fruit Get(int id)
        {
            Fruit findedFruit = fruitDbContext.Fruits.Find(id);
            if (findedFruit != null)
            {
               fruitDbContext.Entry(findedFruit).Reference(x => x.FruitType).Load();
            }
            return findedFruit;
        }

        public List<Fruit> GetAll()
        {
            return fruitDbContext.Fruits.Include("Fruits").ToList();
        }

        public void Create(Fruit fruit)
        {
            fruitDbContext.Fruits.Add(fruit);
            fruitDbContext.SaveChanges();
        }

        public void Update(int id, Fruit fruit)
        {
            Fruit findedFruit = fruitDbContext.Fruits.Find(id);
            if (findedFruit == null)
            {
                return;
            }
            findedFruit.Name = fruit.Name;
            findedFruit.Description = fruit.Description;
            findedFruit.Price = fruit.Price;
            findedFruit.FruitType = fruit.FruitType;
            findedFruit.FruitTypeId = fruit.FruitTypeId;
            fruitDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Fruit findedFruit = fruitDbContext.Fruits.Find(id);
            fruitDbContext.Fruits.Remove(findedFruit);
            fruitDbContext.SaveChanges();
        }
    }
}
