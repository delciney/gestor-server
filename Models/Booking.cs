using System;

namespace BookingCatalog.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Start { get; set; }
        public decimal End { get; set; }
        public int LivingRoomId { get; set; }
        public LivingRoom LivingRoom { get; set; }
    }
}