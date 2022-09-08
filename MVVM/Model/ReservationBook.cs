using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class ReservationBook
    {
        private List<Reservation> _reservation;

        public ReservationBook()
        {
            _reservation = new List<Reservation>();
        }
        /// <summary>
        /// Get The all the Reservations
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Reservation> GetReservations() =>  _reservation.ToList(); 

        public void AddReservation(Reservation resrv) 
        {
            foreach (Reservation existingReservation in _reservation)
            {
                if (existingReservation.Conflicts(resrv))
                    throw new ReservationConflictException(existingReservation,resrv);
            }
            _reservation.Add(resrv);
        }
    }
}
