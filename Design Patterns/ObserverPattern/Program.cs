

using ObserverPattern.Models;

IBM ibm = new IBM("666", 131.23);
ibm.Attach(new Investor("Mitko Banchev"));
ibm.Attach(new Investor("Mato Zahariev"));

ibm.Price = 120.10;
ibm.Price = 121;
ibm.Price = 120.50;
ibm.Price = 120.75;
