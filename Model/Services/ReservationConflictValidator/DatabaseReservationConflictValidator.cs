using Hotel_Model.DBContext;
using Hotel_Model.DTO;
using Microsoft.EntityFrameworkCore;
using MVVM.Model;
using System.Linq;
using System.Threading.Tasks;

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
                ReservationDTO reservationDTO = await context.Reservations.
                    Where(r => r.FloorNum== reservation.roomID.FloorNum).
                    Where(r => r.RoomNum== reservation.roomID.RoomNum).
                    Where(r => r.End>reservation.Start ).
                    Where(r=> r.Start < reservation.End).
                    FirstOrDefaultAsync();
                if (reservationDTO is null)
                    return null;
                return ToReservationMapper(reservationDTO);
            }
        }
        private static Reservation ToReservationMapper(ReservationDTO r)
        {
            return new Reservation(r.UserName, new RoomID(r.FloorNum, r.RoomNum), r.Start, r.End);
        }
    }
}
