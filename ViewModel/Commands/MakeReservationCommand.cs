using MVVM.Model;
using MVVM.Services;
using MVVM.ViewModel;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using ViewModel.Commands;

namespace MVVM.Commands
{
    public class MakeReservationCommand : AsyncCommand
    {
        private readonly Hotel _hotel;
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly NavigationService _reservationNavigationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel,Hotel hotel,NavigationService reservationNavigationService)
        {
            _hotel = hotel;
            _makeReservationViewModel = makeReservationViewModel;
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _reservationNavigationService = reservationNavigationService;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.UserName)||
                e.PropertyName==nameof(MakeReservationViewModel.FloorNum)||
                e.PropertyName==nameof(MakeReservationViewModel.RoomID)) 
            {
                OnCanExecuteChanged();
            }
            
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Reservation resrv = new Reservation(
                _makeReservationViewModel.UserName,
                new RoomID(_makeReservationViewModel.FloorNum, _makeReservationViewModel.RoomID),
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate
                );
            try
            {
                await _hotel.MakeReserbation(resrv);
                MessageBox.Show("Succesfully reserved room", "Enjoy!", MessageBoxButton.OK, MessageBoxImage.Information);
                _reservationNavigationService.Navigate();
            }
            catch (ReservationConflictException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ReservationDateConflict ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed making reservation", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.UserName)&&
                _makeReservationViewModel .FloorNum>0
                && _makeReservationViewModel.RoomID>0
                && base.CanExecute(parameter);
        }
    }
}
