using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public  int Width { get; set; }
        public int Height { get; set; }
        public void Draw()
        {
            DrawLine(this.Width, '*', '*');
            for (int i = 1; i < this.Height; ++i)
            {
                DrawLine(this.Width, '*', ' ');
            }
            DrawLine(this.Width, '*', '*');
        }
        private void DrawLine(int width, char end, char mid)
        {
            Console.WriteLine(end);
            for (int i = 1; i < width-1; ++i)
            {
                Console.WriteLine(mid);
            }
            Console.WriteLine(end);
        }
    }
}
