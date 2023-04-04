using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;
        public string AddBooth(int capacity)
        {
            Booth booth = new Booth(booths.Models.Count+1,capacity);
            booths.AddModel(booth);
            return $"Added booth number {booths.Models.Count} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName!= "MulledWine"&&cocktailTypeName!= "Hibernation")
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }
            if (size!= "Large" && size!= "Middle"&&size!= "Small")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            ICocktail cocktail = null;
            if (cocktailTypeName== "MulledWine")
            {
                cocktail= new MulledWine(cocktailName,size);
            }
            else if (cocktailTypeName== "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            IBooth booth = null;
            foreach (var item in booths.Models)
            {
                if (item.BoothId == boothId)
                {
                    booth = item;
                    break;
                }
            }
            if (!booth.CocktailMenu.Models.Contains(cocktail))
            {
                booth.CocktailMenu.AddModel(cocktail);
                return $"{size} {cocktailName} {cocktailTypeName} added to the pastry";
            }
            else
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName!= "Gingerbread"&&delicacyTypeName!= "Stolen")
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }
            IDelicacy delicacy = null;
            if (delicacyTypeName== "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName== "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            IBooth booth = null;
            foreach (var item in booths.Models)
            {
                if (item.BoothId==boothId)
                {
                    booth = item;
                    break;
                }
            }
            if (!booth.DelicacyMenu.Models.Contains(delicacy))
            {
                booth.DelicacyMenu.AddModel(delicacy);
                return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
            }
            else
            {

                return $"{delicacyName} is already added in the pastry shop!";
            }

        }

        public string BoothReport(int boothId)
        {
            IBooth booth = null;
            foreach (var item in booths.Models)
            {
                if (item.BoothId == boothId)
                {
                    booth = item;
                    break;
                }
            }

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = null;
            foreach (var item in booths.Models)
            {
                if (item.BoothId == boothId)
                {
                    booth = item;
                    break;
                }
            }
            booth.Charge();
            booth.ChangeStatus();
            var result = new StringBuilder();
            result.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            result.AppendLine($"Booth {boothId} is now available!");

            return result.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> result = new List<IBooth>();
            foreach (var item in booths.Models)
            {
                if (item.IsReserved==false&&item.Capacity>=countOfPeople)
                {
                    result.Add(item);
                }
            }
            var firstAvailbleBooth = result.OrderBy(x => x.Capacity).OrderByDescending(x => x.BoothId).First();
            if (firstAvailbleBooth==null)
            {
                return $"No available booth for {countOfPeople} people!";
            }
            firstAvailbleBooth.ChangeStatus();
            return $"Booth {firstAvailbleBooth.BoothId} has been reserved for {countOfPeople} people!";


        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = null;
            foreach (var item in booths.Models)
            {
                if (item.BoothId == boothId)
                {
                    booth = item;
                    break;
                }
            }
            string[] tokens = order.Split("/");
            string itemTypeName = tokens[0];
            string itemName = tokens[1];
            int countOfOrderPieces = int.Parse(tokens[2]);
            ICocktail cocktail = null;
            IDelicacy delicacy = null;

            if (itemTypeName!= "Hibernation" && itemTypeName!= "MulledWine"&&itemTypeName!= "Gingerbread"&&itemTypeName!= "Stolen")
            {
                return $"{itemTypeName} is not recognized type!";
            }

            if (itemTypeName== "Hibernation")
            {
                string size = tokens[3];
                 cocktail = new Hibernation(itemName, size);
            }
            else if (itemTypeName == "MulledWine")
            {
                string size = tokens[3];
                 cocktail = new Hibernation(itemName, size);
            }
            else if (itemTypeName== "Gingerbread")
            {
                 delicacy = new Gingerbread(itemName);
            }
            else
            {
                delicacy = new Stolen(itemName);
            }

            if (cocktail!=null)
            {
                if (!booth.CocktailMenu.Models.Contains(cocktail))
                {
                    return $"There is no {cocktail.Size} {itemName} available!";
                }
                booth.UpdateCurrentBill(cocktail.Price * countOfOrderPieces);
                return $"Booth {boothId} ordered {countOfOrderPieces} {itemName}!";
            }
            else
            {
                if (!booth.DelicacyMenu.Models.Contains(delicacy))
                {
                    return $"There is no {itemTypeName} {itemName} available!";

                }
                booth.UpdateCurrentBill(delicacy.Price * countOfOrderPieces);
                return $"Booth {boothId} ordered {countOfOrderPieces} {itemName}!";
            }

        }
    }
}
