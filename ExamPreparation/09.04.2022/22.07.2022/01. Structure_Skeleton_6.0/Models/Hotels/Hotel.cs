using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            Rooms = new RoomRepository();
            Bookings = new BookingRepository();
            

           
        }
        private string fullName;
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }
                fullName = value;
            }
        }

        private int category;
        public int Category
        {
            get => category;
            private set
            {
                if (value<1||value>5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }
                category = value;
            }
        }

       
        public double Turnover { get => ReturnTurnover();   }

        private IRepository<IRoom> rooms;
        public IRepository<IRoom> Rooms {get => rooms;private set { rooms = value; } }

        private IRepository<IBooking> bookings;
        public IRepository<IBooking> Bookings { get => bookings; private set { bookings = value; } }
        private  double ReturnTurnover()
        {
            var allBooks = Bookings.All();
            var result = allBooks.Sum(b => b.Room.PricePerNight * b.ResidenceDuration);
            return result;
        }
    }
}
