using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get => height;
            set
            {
                if (height > 0)
                {
                    value = height;
                }
            }
        }
        public double Width
        {
            get=> width;
            set
            {
                if (width>0)
                {
                    value = width;
                }
            }

        }
        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
           return Height*2+Width*2;
        }
        public override string Draw()
        {
            return base.Draw()+ " Rectangle";
        }
    }
}
