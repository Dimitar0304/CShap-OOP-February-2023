﻿using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;
        public BookingRepository()
        {
            bookings= new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
           bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
           return bookings.AsReadOnly();
        }

        public IBooking Select(string criteria)
        {
            return bookings.FirstOrDefault(x => x.BookingNumber == int.Parse(criteria));
        }
    }
}
