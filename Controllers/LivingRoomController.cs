using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingCatalog.Data;
using BookingCatalog.Models;
using Microsoft.AspNetCore.Cors;

namespace BookingCatalog.Controllers
{
    // [EnableCors("MyPolicy")]
    public class CategoryController : Controller
    {
        private readonly StoreDataContext _context;

        public CategoryController(StoreDataContext context)
        {
            _context = context;
        }

        [Route("v1/LivingRooms")]
        [HttpGet]
        public IEnumerable<LivingRoom> Get()
        {
            return _context.LivingRooms.AsNoTracking().ToList();
        }

        [Route("v1/LivingRooms/{id}")]
        [HttpGet]
        public LivingRoom Get(int id)
        {
            // Find() ainda não suporta AsNoTracking
            return _context.LivingRooms.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/LivingRooms")]
        [HttpPost]
        public LivingRoom Post([FromBody] LivingRoom livingRoom)
        {
            _context.LivingRooms.Add(livingRoom);
            _context.SaveChanges();

            return livingRoom;
        }

        [Route("v1/LivingRooms")]
        [HttpPut]
        public LivingRoom Put([FromBody] LivingRoom livingRoom)
        {
            _context.Entry<LivingRoom>(livingRoom).State = EntityState.Modified;
            _context.SaveChanges();

            return livingRoom;
        }

        [Route("v1/LivingRooms")]
        [HttpDelete]
        public LivingRoom Delete([FromBody] LivingRoom livingRoom)
        {
            _context.LivingRooms.Remove(livingRoom);
            _context.SaveChanges();

            return livingRoom;
        }
    }
}