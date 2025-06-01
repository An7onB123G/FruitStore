using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Data
{
    public class FruitType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Fruit> Fruits { get; set; }
    }
}
