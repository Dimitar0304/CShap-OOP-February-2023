using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }
        private int bedCapacity;
        public int BedCapacity { get => bedCapacity;private set { bedCapacity = value; } }

        private double pricePerNight;
        public double PricePerNight
        {
            get => pricePerNight;
           private  set
            {
                if (value<0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
