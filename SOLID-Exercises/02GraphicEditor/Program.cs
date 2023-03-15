namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor gE = new GraphicEditor();

            List<Shape> shapes = new List<Shape>(); 

            Shape circle = new Circle();
            Shape rectangle = new Rectangle();
            Shape square = new Square();

            shapes.Add(circle);
            shapes.Add(rectangle);  
            shapes.Add(square);

            foreach (var item in shapes)
            {
                gE.DrawShape(item);
            }
        }
    }
}
