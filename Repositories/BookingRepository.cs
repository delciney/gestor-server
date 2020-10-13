using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookingCatalog.Data;
using BookingCatalog.Models;
using BookingCatalog.ViewModels.BookingViewModels;

namespace BookingCatalog.Repositories
{
    public class BookingRepository
    {
        private readonly StoreDataContext _context;

        public BookingRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<ListBookingViewModel> Get()
        {
            return _context
                .Bookings
                .Include(x => x.LivingRoom)
                .Select(x => new ListBookingViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    BookingDate = x.BookingDate,
                    Start = x.Start,
                    End = x.End,
                    LivingRoom = x.LivingRoom.Title,
                    LivingRoomId = x.LivingRoom.Id
                })
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<ListBookingViewModel> Filter(DateTime ReceivedBookingDate, decimal ReceivedStart, decimal ReceivedEnd, int ReceivedLivingRoomId)
        {
            return _context
                .Bookings
                .Include(x => x.LivingRoom)
                .Select(x => new ListBookingViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    BookingDate = x.BookingDate,
                    Start = x.Start,
                    End = x.End,
                    LivingRoom = x.LivingRoom.Title,
                    LivingRoomId = x.LivingRoom.Id
                })
                .Where(d => d.LivingRoomId == ReceivedLivingRoomId)
                .Where(d => d.BookingDate == ReceivedBookingDate)
                .Where(s => s.Start >= ReceivedStart)
                .Where(e => e.End <= ReceivedEnd)
                .AsNoTracking()
                .ToList();
        }
        public IEnumerable<ListBookingViewModel> List(DateTime ReceivedBookingDate, decimal ReceivedStart, decimal ReceivedEnd)
        {
            return _context
                .Bookings
                .Include(x => x.LivingRoom)
                .Select(x => new ListBookingViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    BookingDate = x.BookingDate,
                    Start = x.Start,
                    End = x.End,
                    LivingRoom = x.LivingRoom.Title,
                    LivingRoomId = x.LivingRoom.Id
                })
                .Where(d => d.BookingDate == ReceivedBookingDate)
                .Where(s => s.Start >= ReceivedStart)
                .Where(e => e.End <= ReceivedEnd)
                .AsNoTracking()
                .ToList();
        }
        public Booking Get(int id)
        {
            return _context.Bookings.Find(id);
        }


        public void Save(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
        public void Update(Booking booking)
        {
            _context.Entry<Booking>(booking).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}