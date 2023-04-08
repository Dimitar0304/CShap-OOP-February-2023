using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        public Controller()
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            Hotel hotel = new Hotel(hotelName, category);
            var allhotel = hotels.All();
            if (!allhotel.Contains(hotel))
            {
                hotels.AddNew(hotel);
                return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
            }
            else
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var allhotels = hotels.All().OrderBy(x => x.FullName).Where(r=>r.Category==category);
            if (allhotels.Count()==0)
            {
                return $"{category} star hotel is not available in our platform.";
            }
            List<IRoom> allRooms = new List<IRoom>();
            foreach (var hotel in allhotels)
            {
                var curentRooms = hotel.Rooms.All().Where(r => r.PricePerNight > 0);
                foreach (var room in curentRooms)
                {
                    allRooms.Add(room);
                }
                
            }
           allRooms= allRooms.OrderBy(r => r.BedCapacity).ToList();
            int guest = adults + children;

            var allRoomsWichFitGuests = allRooms.Where(r => r.BedCapacity >= guest);
            if (allRoomsWichFitGuests.Count()==0)
            {
                return $"We cannot offer appropriate room for your request.";
            }
            var chosenRoom = allRoomsWichFitGuests.First();
            var chosenHotel = allhotels.First(h=>h.Rooms.All().Contains(chosenRoom));

            IBooking booking = new Booking(chosenRoom, duration, adults, children, chosenHotel.Bookings.All().Count() + 1);
            chosenHotel.Bookings.AddNew(booking);
            
            return $"Booking number {booking.BookingNumber} for {chosenHotel.FullName} hotel is successful!";

        }

        public string HotelReport(string hotelName)
        {
            var allhotels = hotels.All();
            var hotel = allhotels.FirstOrDefault(x=>x.FullName==hotelName);
            if (hotel==null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            var sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine("--Bookings:");
            if (hotel.Bookings.All().Count()==0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var book in hotel.Bookings.All())
                {
                    sb.AppendLine(book.BookingSummary());
                    sb.AppendLine();
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var allhotel = hotels.All();
            var curentHotel = allhotel.FirstOrDefault(x => x.FullName == hotelName);
            if (curentHotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
            {
                throw new ArgumentException("Incorrect room type!");
            }
            var rooms = curentHotel.Rooms.All();
            IRoom currentRoom =rooms.FirstOrDefault(r => r.GetType().Name == roomTypeName);
            if (currentRoom==null)
            {
                return "Room type is not created yet!";
            }
            if (currentRoom.PricePerNight > 0)
            {
                throw new InvalidOperationException("Price is already set!");
            }
            else
            {
                currentRoom.SetPrice(price);
                return $"Price of {currentRoom.GetType().Name} room type in {hotelName} hotel is set!";
            }
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var allhotel = hotels.All();
            var curentHotel = allhotel.FirstOrDefault(x => x.FullName == hotelName);
            if (curentHotel==null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }
            if (roomTypeName!="Apartment"&&roomTypeName!="DoubleBed"&&roomTypeName!="Studio")
            {
                throw new ArgumentException("Incorrect room type!");
            }
            IRoom room = null;
            switch (roomTypeName)
            {
                case "Apartment":
                    room = new Apartment();
                    break;
                case "DoubleBed":
                    room = new DoubleBed();
                    break;
                case "Studio":
                    room = new Studio();
                    break;
            }
            var rooms = curentHotel.Rooms.All();
            if (rooms.Contains(room))
            {
                return $"Room type is already created!";
            }
            curentHotel.Rooms.AddNew(room);

            return $"Successfully added {room.GetType().Name} room type in {hotelName} hotel!";
        }
    }
}
