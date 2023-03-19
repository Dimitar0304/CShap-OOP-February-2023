using System.Dynamic;
using System.Reflection;
using System.Threading.Channels;


//how to get type by reflection
//Type type = typeof(Product);

//Console.WriteLine($" Name of type :{type.Name}");
//Console.WriteLine($" Is Abstract:{type.IsAbstract}");
//Console.WriteLine($" IsPublic:{type.IsPublic}");
//Console.WriteLine($"  IsInterface:{type.IsInterface}");
//Console.WriteLine($" Base type of this type:{type.BaseType}");
//Console.WriteLine(type.IsClass);

//-------------------------------------------

//how to get fields of class


//Type type = typeof(Product);
//FieldInfo[] field = type.GetFields(BindingFlags.NonPublic|BindingFlags.Instance);
//foreach (FieldInfo fieldInfo in field)
//{
//    Console.WriteLine(fieldInfo.Name);
//}

//------------------------------

//how to get properties
//Type type = typeof(Product);
//PropertyInfo[] properties = type.GetProperties(BindingFlags.NonPublic
//    |BindingFlags.Public|BindingFlags.Instance);
//foreach (PropertyInfo property in properties)
//{
//    Console.WriteLine(property.Name);
//}

//---------------------
//how to get Methods
//Type type = typeof(Product);
//MethodInfo[]  methods= type.GetMethods(BindingFlags.Public|BindingFlags.NonPublic
//    |BindingFlags.Instance);
//foreach (var method in methods)
//{
//    Console.WriteLine(method.Name);
//}

//------------------
//some more practice

//Type type = typeof(Product);

//PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance 
//    | BindingFlags.Public|BindingFlags.NonPublic);

//Product product = new Product();
//int value = 5;
//PropertyInfo propertyInfo = product.GetType().GetProperty("Id");
//propertyInfo.SetValue(product, value, null);
//Console.WriteLine(product.GetType().GetProperty("Id").GetValue(type));
//string input = Console.ReadLine();

//Type type = typeof(DateTime);

//Console.WriteLine(type.Name);
//Console.WriteLine(type.DeclaringType);
//Console.WriteLine(type.BaseType);


object obj = typeof(Product);
ConstructorInfo ctor = typeof(Product).GetConstructor("1", 10);

Console.WriteLine();





public  class Product
{
    public Product(string id, int price)
    {
        Id = id;
        Price = price;
    }

    public string Id { get; set; }
    public int Price { get; set; }
}