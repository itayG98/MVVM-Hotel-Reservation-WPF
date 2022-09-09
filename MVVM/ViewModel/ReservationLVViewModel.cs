using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class ReservationLVViewModel:ViewModelBase
    {
        public ICommand MakeReservation { get; }

        public ReservationLVViewModel()
        {

        }
    }
}
