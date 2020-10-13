using System;

namespace BookingCatalog.ViewModels.BookingViewModels
{
    public class ListBookingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Start { get; set; }
        public decimal End { get; set; }
        public int LivingRoomId { get; set; }
        public string LivingRoom { get; set; }
    }
}