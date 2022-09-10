using MVVM.Commands;
using MVVM.Model;
using MVVM.Sores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class ReservationLVViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }

        public ReservationLVViewModel(NavigationStore navigationStore)
        {
            MakeReservationCommand = new NavigateCommand(navigationStore);
            _reservations = new ObservableCollection<ReservationViewModel>();

            _reservations.Add(new ReservationViewModel(new Reservation("Itay", new RoomID(1, 1), new DateTime(2022, 1, 1), new DateTime(2022, 1, 10))));
            _reservations.Add(new ReservationViewModel(new Reservation("Itay", new RoomID(1, 1), new DateTime(2022, 2, 1), new DateTime(2022, 2, 10))));
            _reservations.Add(new ReservationViewModel(new Reservation("Shon", new RoomID(2, 1), new DateTime(2022, 2, 1), new DateTime(2022, 2, 10))));
            _reservations.Add(new ReservationViewModel(new Reservation("Shon", new RoomID(2, 2), new DateTime(2022, 2, 12), new DateTime(2022, 2, 14))));
            _reservations.Add(new ReservationViewModel(new Reservation("Shon", new RoomID(2, 2), new DateTime(2022, 1, 1), new DateTime(2022, 1, 7))));

        }
    }
}
