using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class Hotel
    {
        private ReservationBook _reservationBook;
        private string _name;   

        public Hotel(string name)
        {
            _reservationBook = new ReservationBook();
            _name = name;   
        }

        /// <summary>
        /// Get reservation for a user
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns>The User's reservation</returns>
        public IEnumerable<Reservation> GetReservationsForUser(string UserName)
            => _reservationBook.GetReservationsForUser(UserName);

        /// <summary>
        /// Make a new reservation
        /// </summary>
        /// <param name="Reservation to make"></param>
        /// <exception cref="ReservationConflictException"></exception>
        public void MakeReserbation(Reservation reserv)
            => _reservationBook.AddReservation(reserv);
    }
}
