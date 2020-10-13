using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookingCatalog.Models;
using BookingCatalog.Repositories;
using BookingCatalog.ViewModels.BookingViewModels;
using Microsoft.AspNetCore.Cors;

namespace BookingCatalog.Controllers
{
    // [EnableCors("MyPolicy")]
    public class BookingController : Controller
    {
        private readonly BookingRepository _repository;

        public BookingController(BookingRepository repository)
        {
            _repository = repository;
        }
        [Route("/")]
        [HttpGet]
        public IEnumerable<ListBookingViewModel> Get()
        {
            return "Server on";
        }
        [Route("v1/Bookings")]
        [HttpGet]
        public IEnumerable<ListBookingViewModel> Get()
        {
            return _repository.Get();
        }

        [Route("v1/Bookings/{id}")]
        [HttpGet]
        public Booking Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/Bookings")]
        [HttpPost]
        public ResultViewModel Post([FromBody] EditorBookingViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível realizar a reserva",
                    Data = model.Notifications
                };

            // Se tiver uma reserva para essa data não reservar
            var filter = _repository.Filter(model.BookingDate, model.Start, model.End, model.LivingRoomId);

            int results = 0;

            foreach (var f in filter)
            {
                results++;
            }
            if (results > 0)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível realizar a reserva, sala já reservada",
                    Data = filter
                };
            }
            var booking = new Booking();
            booking.Title = model.Title;
            booking.BookingDate = model.BookingDate;
            booking.Start = model.Start;
            booking.End = model.End;
            booking.LivingRoomId = model.LivingRoomId;

            _repository.Save(booking);

            return new ResultViewModel
            {
                Success = true,
                Message = "Reserva realizada com sucesso!",
                Data = booking
            };
        }


        [Route("v1/Bookings")]
        [HttpPut]
        public ResultViewModel Put([FromBody] EditorBookingViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar a reserva",
                    Data = model.Notifications
                };

            var booking = _repository.Get(model.Id);
            booking.Title = model.Title;
            booking.BookingDate = model.BookingDate;
            booking.Start = model.Start;
            booking.End = model.End;
            booking.LivingRoomId = model.LivingRoomId;

            _repository.Update(booking);

            return new ResultViewModel
            {
                Success = true,
                Message = "Reserva alterada com sucesso!",
                Data = booking
            };
        }

    }
}