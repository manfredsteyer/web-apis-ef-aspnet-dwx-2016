using HotelApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApi
{
    public class HotelRepository: IDisposable
    {
        HotelDbContext ctx = new HotelDbContext();

        public Hotel FindById(int id)
        {
            return ctx
                    .Hotel
                    .Include(h => h.HotelBuchung)
                    .Where(h => h.HotelId == id)
                    .FirstOrDefault();

        }

        public List<Hotel> FindAll()
        {
            return ctx.Hotel.ToList();
        }

        public List<Hotel> FindByRegion(int regionId)
        {
            return ctx
                    .Hotel
                    .Where(h => h.RegionId == regionId)
                    .ToList();
        }

        public void CreateHotel(Hotel hotel)
        {
            ctx.Hotel.Add(hotel);
            ctx.SaveChanges();
        }

        public void UpdateHotel(Hotel hotel) {
            ctx.Hotel.Attach(hotel);
            ctx.Entry(hotel).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
