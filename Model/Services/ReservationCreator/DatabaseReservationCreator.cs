using Hotel_Model.DBContext;
using Hotel_Model.DTO;
using Microsoft.EntityFrameworkCore;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Services.ReservationCreator
{
    public class DatabaseReservationCreator : IreservationCreator
    {
        private readonly ReserveRoomDbFactory _dbContextFactory;

        public DatabaseReservationCreator(ReserveRoomDbFactory reserveRoomDbFactory)
        {
            _dbContextFactory = reserveRoomDbFactory;
        }
        public async Task CreateReservation(Reservation reservation)
        {
            using (ReserveRoomDBContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = ToReservationDROMapper(reservation);
                context.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }
        private static ReservationDTO ToReservationDROMapper(Reservation r)
        {
            return new ReservationDTO()
            {
                FloorNum = r.roomID?.FloorNum ?? 0,
                RoomNum = r.roomID?.RoomNum ?? 0,
                UserName = r.UserName,
                Start = r.Start,
                End = r.End
            };
        }
    }
}
