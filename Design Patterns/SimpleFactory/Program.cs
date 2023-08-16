


using SimpleFactory;



ICar audi = CarFactory.MakeAudi(400, 50);

ICar bmw = CarFactory.MakeBMW(350, 60);

Console.WriteLine(audi.GetType().Name);
Console.WriteLine(bmw.GetType().Name);