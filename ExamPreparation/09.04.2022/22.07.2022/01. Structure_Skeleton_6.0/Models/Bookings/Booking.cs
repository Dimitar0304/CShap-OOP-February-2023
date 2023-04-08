using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }
        private IRoom room;
        public IRoom Room { get => room;private set { room = value; } }

        private int residenceDuration;
        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }
                residenceDuration = value;

            }
        }

        private int adultsCount;
        public int AdultsCount
        {
            get => adultsCount;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }
                adultsCount = value;
            }
        }

        private int childrenCount;
        public int ChildrenCount
        {
            get => childrenCount;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }
                childrenCount = value;
            }
        }

        private int bookingNumber;

        public int BookingNumber
        {
            get => bookingNumber;
            private set { bookingNumber = value; }  
        }

        public string BookingSummary()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid():F2}");
            return sb.ToString().Trim();
        }
        private double TotalPaid()
        {
            return Math.Round(ResidenceDuration * Room.PricePerNight);
        }
    }
}
