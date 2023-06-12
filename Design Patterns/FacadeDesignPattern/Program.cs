

using FacadeDesignPattern;

Customer customer = new Customer("Mitko");
Mortgage mortgage = new Mortgage(customer);

while (true)
{
    string command = Console.ReadLine();

	switch (command)
	{
		case"WhatIsMyBalance":
			mortgage.customer.Bank.WhatIsMyBalace();
			break;
		case "GetCredit":
			mortgage.GetCredit();
			break;
		case "AddSumToCredit":
			mortgage.customer.Credit.AddSumToCredit(decimal.Parse(Console.ReadLine()));	
			break;
		case "End":
			return;

			break;
			
	}
}
