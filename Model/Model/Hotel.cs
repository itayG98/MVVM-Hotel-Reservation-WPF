using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class Hotel
    {
        private ReservationBook _reservationBook;
        private string _name;

        public Hotel(string name, ReservationBook reservationBook)
        {
            _reservationBook = reservationBook;
            _name = name;
        }

        /// <summary>
        /// Get reservation for a user
        /// </summary>
        /// <returns>The User's reservation</returns>
        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await _reservationBook.GetReservations();
        }
        /// <summary>
        /// Make a new reservation
        /// </summary>
        /// <param name="Reservation to make"></param>
        /// <exception cref="ReservationConflictException"></exception>
        public async Task MakeReserbation(Reservation reserv)
        { 
            await _reservationBook.AddReservation(reserv);
        }
    }
}
