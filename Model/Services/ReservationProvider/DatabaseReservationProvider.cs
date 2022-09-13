using Hotel_Model.DBContext;
using Hotel_Model.DTO;
using Microsoft.EntityFrameworkCore;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Services.ReservationProvider
{
    public class DatabaseReservationProvider : IReservationProvider
    {
        private readonly ReserveRoomDbFactory _dbContextFactory;

        public DatabaseReservationProvider(ReserveRoomDbFactory reserveRoomDbFactory)
        {
            _dbContextFactory = reserveRoomDbFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservation()
        {
            using (ReserveRoomDBContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();
                return reservationDTOs.Select
                    (r => ToReservationMapper(r)).
                    ToList().OrderBy(r=> r.Start);
            } 
        }

        private static Reservation ToReservationMapper(ReservationDTO r)
        {
            return new Reservation(r.UserName,new RoomID(r.FloorNum, r.RoomNum), r.Start,   r.End);
        }
    }
}
