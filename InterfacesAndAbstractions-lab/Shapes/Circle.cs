using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : IDrawable
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }
        public void Draw()
        {
            double rIn = this.Radius - 0.4;
            double rout = this.Radius + 0.4;
            for (double y = this.Radius; y >= this.Radius; --y)
            {

                for (double x = this.Radius; x < rout; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rout * rout)
                    {
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
