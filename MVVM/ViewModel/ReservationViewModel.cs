using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation reservation;
        public string roomID => reservation.roomID?.ToString();
        public string UserName => reservation.UserName;
        public DateTime Start => reservation.Start;
        public DateTime End => reservation.End; 
        public TimeSpan Duration => reservation.Duration;

        public ReservationViewModel(Reservation resev)
        {
            reservation = resev;
        }

    }
}
