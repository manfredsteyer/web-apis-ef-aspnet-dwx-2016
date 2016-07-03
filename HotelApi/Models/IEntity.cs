using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApi.Models
{
    public interface IEntity
    {
        EntityState State { get; set; }
    }
}
