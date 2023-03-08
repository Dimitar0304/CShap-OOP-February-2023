

using CollectionHierarchy;

List <Collection> addbleList = new List<Collection>(3);
Collection addCollection = new AddCollection();
Collection addRemoveCollection = new AddRemoveCollection();
Collection myList = new MyList();

addbleList.Add(addCollection); 
addbleList.Add(addRemoveCollection);
addbleList.Add(myList);



string[] items = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
foreach (var collection in addbleList)
{
	foreach (var item in items)
	{
        Console.Write($"{collection.Add(item)} ");
    }
    Console.WriteLine();
}
int coutToRemoveCommand = int.Parse(Console.ReadLine());



List<Collection> removebleList = new List<Collection>(2);
removebleList.Add(addRemoveCollection);
removebleList.Add(myList);  





foreach (var collection in removebleList)
{
	for (int i = 0; i < coutToRemoveCommand; i++)
	{
        Console.Write($"{collection.Remove()} ");
    }
    Console.WriteLine();
}


