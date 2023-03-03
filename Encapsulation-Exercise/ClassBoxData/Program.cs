using ClassBoxData;

double l = double.Parse(Console.ReadLine());
double w = double.Parse(Console.ReadLine());
double h = double.Parse(Console.ReadLine());

try
{
Box box =new Box(l, w, h);

Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
Console.WriteLine($"Volume - {box.Volume():F2}");

}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}