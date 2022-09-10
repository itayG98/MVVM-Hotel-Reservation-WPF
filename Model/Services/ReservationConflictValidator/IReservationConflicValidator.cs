using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Model.Services.ReservationConflictValidator
{
    public interface IReservationConflicValidator
    {
        Task<Reservation> GetConflictReservation(Reservation reservation);
    }
}
