using MVVM.Model;
using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.Commands
{
    internal class SubmitNewReservation : CommandBase
    {
        private readonly Hotel _hotel;
        private readonly MakeReservationViewModel _makeReservationViewModel;
        public SubmitNewReservation(MakeReservationViewModel makeReservationViewModel,Hotel hotel)
        {
            _hotel = hotel;
            _makeReservationViewModel = makeReservationViewModel;
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
    }
}
