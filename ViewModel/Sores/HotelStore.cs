using Hotel_Model.Migrations;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Sores
{
    public class HotelStore
    {
        private readonly Hotel _hotel;
        private readonly List<Reservation>  _reservation;
        private readonly Lazy<Task> _initLazy;

        public IEnumerable<Reservation> Reservations => _reservation;

        public HotelStore(Hotel hotel)
        {
            _reservation = new List<Reservation>();
            _hotel = hotel;
            _initLazy = new Lazy<Task>(Initialize);
        }

        public async Task MakeReservation(Reservation reservation)
        {
            await _hotel.MakeReserbation(reservation);
            _reservation.Add(reservation);
        }
        private async Task Initialize()
        {
            IEnumerable<Reservation> reservations = await _hotel.GetReservations();
            _reservation.Clear();
            _reservation.AddRange(reservations);
        }
        public async Task Load() => await _initLazy.Value;
        
    }
}
