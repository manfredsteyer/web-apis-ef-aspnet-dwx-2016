using HotelApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelApi.Controllers
{
    public class HotelController : ApiController
    {
        HotelRepository repo = new HotelRepository();

        public Hotel GetById(int id) {
            return repo.FindById(id);
        }

        public List<Hotel> GetAll() {
            return repo.FindAll();
        }

        public List<Hotel> GetByRegion(int regionId) {
            return repo.FindByRegion(regionId);
        }

        public void PostHotel(Hotel hotel) {
            repo.CreateHotel(hotel);
        }

        public void PutHotel(int id, Hotel hotel) {
            hotel.HotelId = id;
            repo.UpdateHotel(hotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                this.repo.Dispose();
            }
        }
    }
}
