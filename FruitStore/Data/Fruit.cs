using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Data
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int FruitTypeId { get; set; }
        public FruitType FruitType { get; set; } // Kogato go napravq FruitTypes Syzdava oshte edna kolona v tablicata

    }
}
