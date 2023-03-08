using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set
            {
                if (radius>0)
                {
                    value = radius;
                }
            }
        }

        public override double CalculateArea()
        {
           return Math.PI * Math.Pow(Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }
        public override string Draw()
        {
            return base.Draw()+" Circle";
        }
    }
}
