using MVVM.Model;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.Commands
{
    internal class SubmitNewReservationCommand : CommandBase
    {
        private readonly Hotel _hotel;
        private readonly MakeReservationViewModel _makeReservationViewModel;

        public SubmitNewReservationCommand(MakeReservationViewModel makeReservationViewModel,Hotel hotel)
        {
            _hotel = hotel;
            _makeReservationViewModel = makeReservationViewModel;
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
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

        public override void Execute(object? parameter)
        {
            Reservation resrv = new Reservation(
                _makeReservationViewModel.UserName,
                new RoomID(_makeReservationViewModel.FloorNum, _makeReservationViewModel.RoomID),
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate
                );
            try 
            {
                _hotel.MakeReserbation(resrv);
                MessageBox.Show("Succesfully reserved room", "Enjoy!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ReservationConflictException ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            catch (ReservationDateConflict ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
