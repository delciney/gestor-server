using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace BookingCatalog.ViewModels.BookingViewModels
{
    public class EditorBookingViewModel : Notifiable, IValidatable
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Start { get; set; }
        public decimal End { get; set; }
        public int LivingRoomId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Title, 120, "Title", "O título deve conter até 120 caracteres")
                    .HasMinLen(Title, 3, "Title", "O título deve conter pelo menos 3 caracteres")
            );
        }
    }
}