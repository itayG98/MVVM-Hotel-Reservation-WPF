using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class ReservationLVViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public ICommand MakeReservation { get; }

        public ReservationLVViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
        }
    }
}
