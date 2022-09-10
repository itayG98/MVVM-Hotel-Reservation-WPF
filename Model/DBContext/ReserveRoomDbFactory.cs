using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Model.DBContext
{
    public class ReserveRoomDbFactory
    {
        private readonly string _connectionString ;

        public ReserveRoomDbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ReserveRoomDBContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;
            return new ReserveRoomDBContext(options);
        }
    }
}
