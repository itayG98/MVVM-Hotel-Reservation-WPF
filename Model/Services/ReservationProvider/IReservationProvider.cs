using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Services.ReservationProvider
{
    public interface IReservationProvider
    {
        Task<IEnumerable<Reservation>> GetAllReservation();
    }
}
