using MVVM.Commands;
using MVVM.Model;
using MVVM.Services;
using MVVM.Sores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class ReservationLVViewModel : ViewModelBase
    {
        private readonly Hotel _hotel;
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }

        public ReservationLVViewModel(Hotel hotel,NavigationService makeReservationNavitaionService)
        {
            _hotel = hotel;
            MakeReservationCommand = new NavigateCommand(makeReservationNavitaionService);
            _reservations = new ObservableCollection<ReservationViewModel>();
            UpdateReservation();
        }

        private void UpdateReservation()
        {
            _reservations.Clear();
            foreach (Reservation reserv in _hotel.GetReservations())
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reserv);
                _reservations.Add(reservationViewModel);
            }
        }
    }
}
