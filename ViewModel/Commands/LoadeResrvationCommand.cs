using MVVM.Model;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using ViewModel.Sores;

namespace ViewModel.Commands
{
    internal class LoadeResrvationCommand : AsyncCommand
    {
        private readonly HotelStore _hotelStore;
        private readonly ReservationLVViewModel _ViewModel;

        public LoadeResrvationCommand(HotelStore hotelStore, ReservationLVViewModel viewModel)
        {
            _hotelStore = hotelStore;
            _ViewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                 await _hotelStore.Load();
                _ViewModel.UpdateReservation(_hotelStore.Reservations);
            }
            catch
            {
                MessageBox.Show("Failed to laod reservations", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
