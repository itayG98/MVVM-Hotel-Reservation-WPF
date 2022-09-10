using MVVM.Model;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel.Commands
{
    internal class LoadeResrvationCommand : AsyncCommand
    {
        private readonly Hotel _hotel;
        private readonly ReservationLVViewModel _ViewModel;

        public LoadeResrvationCommand(Hotel hotel, ReservationLVViewModel viewModel)
        {
            _hotel = hotel;
            _ViewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Reservation> reservations = await _hotel.GetReservations();
                _ViewModel.UpdateReservation(reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to laod reservations", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
