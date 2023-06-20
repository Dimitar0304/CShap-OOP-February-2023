using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoTypeDesignPattern.Models
{
    public class Car : CarPrototype
    {
        private int hp;
        private int engine;
        private string color;
        public Car(int hp, int engine, string color)
        {
            this.hp = hp;
            this.engine = engine;
            this.color = color;
        }
        public override CarPrototype Clone()
        {
            Console.WriteLine($"Cloning car: Engine is {engine}, with {hp} hp in {color} color ");

            return this.MemberwiseClone() as CarPrototype;
        }
        public override string ToString()
        {
            return $"This is Audi A3 in {color} color with {engine} engine and {hp} hp";
        }
    }
}
