using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookingCatalog.Models;
using BookingCatalog.Repositories;
using BookingCatalog.ViewModels.BookingViewModels;

namespace BookingCatalog.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly BookingRepository _repository;

        public ConsultationController(BookingRepository repository)
        {
            _repository = repository;
        }


        [Route("v1/Consultations")]
        [HttpPost]
        public ResultViewModel Post([FromBody] EditorBookingViewModel model)
        {
            var list = _repository.List(model.BookingDate, model.Start, model.End);

            return new ResultViewModel
            {
                Success = true,
                Message = "Consulta realizada com sucesso",
                Data = list
            };


        }

    }
}