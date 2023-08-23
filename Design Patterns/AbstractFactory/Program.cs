

using AbstractFactory.Models;
using AbstractFactory.Models.Interfaces;

BmwFactory bmwFactory = new BmwFactory();
ICar bmw= bmwFactory.MakeCar();
IMechanic bmwMechanic = bmwFactory.InitialiseMechanic();

bmw.GetDescription();
bmwMechanic.GetDescription();

AudiFactory audiFactory = new AudiFactory();
IMechanic mechanic = audiFactory.InitialiseMechanic();
 ICar audi = audiFactory.MakeCar();

mechanic.GetDescription();
audi.GetDescription();
