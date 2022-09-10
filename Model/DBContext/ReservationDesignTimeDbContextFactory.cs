using Hotel_Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Model.DBContext
{
    internal class ReservationDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReserveRoomDBContext>
    {
        public ReserveRoomDBContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer("Data Source = HotelDB.db ").Options;
            return new ReserveRoomDBContext(options);
        }
        public ReserveRoomDBContext CreateDbContext(string connectioString)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(connectioString).Options;
            return new ReserveRoomDBContext(options);
        }
    }
}
