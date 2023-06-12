
using ReadCitiesAndTheirPopulation;



SingletonDataContainer singleton = SingletonDataContainer.Instance();
Console.WriteLine(singleton.GetPopulation("London"));
SingletonDataContainer singletonDataContaine = SingletonDataContainer.Instance();
Console.WriteLine(singletonDataContaine.GetPopulation("Hello"));