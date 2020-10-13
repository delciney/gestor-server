using System;
using System.Collections.Generic;

namespace BookingCatalog.Models
{
    public class LivingRoom
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Equipment { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}