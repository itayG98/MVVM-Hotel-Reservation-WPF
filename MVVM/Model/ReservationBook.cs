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
        public IEnumerable<Reservation> GetReservationsForUser(string UserName) =>  _reservation.Where(x => x.UserName == UserName); 

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
