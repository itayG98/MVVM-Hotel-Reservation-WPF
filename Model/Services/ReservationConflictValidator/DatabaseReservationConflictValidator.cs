using Hotel_Model.DBContext;
using Hotel_Model.DTO;
using Microsoft.EntityFrameworkCore;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Services.ReservationCreator;

namespace Hotel_Model.Services.ReservationConflictValidator
{
    public class DatabaseReservationConflictValidator : IReservationConflicValidator
    {

        private readonly ReserveRoomDbFactory _dbContextFactory;

        public DatabaseReservationConflictValidator(ReserveRoomDbFactory reserveRoomDbFactory)
        {
            _dbContextFactory = reserveRoomDbFactory;
        }
        public async Task<Reservation> GetConflictReservation(Reservation reservation)
        {
            using (ReserveRoomDBContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Reservations.
                    Select(r => ToReservationMapper(r)).
                    FirstOrDefaultAsync(r => r.Conflicts(reservation));
            }
        }
        private static Reservation ToReservationMapper(ReservationDTO r)
        {
            return new Reservation(r.UserName, new RoomID(r.FloorNum, r.RoomNum), r.Start, r.End);
        }
    }
}
