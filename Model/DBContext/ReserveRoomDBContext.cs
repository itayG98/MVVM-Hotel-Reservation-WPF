using Hotel_Model.DTO;
using Microsoft.EntityFrameworkCore;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Model.DBContext
{
    public class ReserveRoomDBContext : DbContext
    {
        public DbSet<ReservationDTO> Reservations { get; set; }
    }
}
