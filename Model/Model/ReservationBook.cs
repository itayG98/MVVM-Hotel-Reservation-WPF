using Hotel_Model.Services.ReservationConflictValidator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Services.ReservationCreator;
using ViewModel.Services.ReservationProvider;

namespace MVVM.Model
{
    public class ReservationBook
    {
        private IReservationProvider _resevationProvider;
        private IreservationCreator _reservationCreator;
        private IReservationConflicValidator _reservationConflicValidator;

        public ReservationBook(IReservationProvider resevationProvider, IreservationCreator reservationCreator, IReservationConflicValidator reservationConflicValidator)
        {
            _resevationProvider = resevationProvider;
            _reservationCreator = reservationCreator;
            _reservationConflicValidator = reservationConflicValidator;
        }


        /// <summary>
        /// Get The all the Reservations
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Reservation>> GetReservations() => await _resevationProvider.GetAllReservation();
        public async Task AddReservation(Reservation resrv) 
        {
            if (resrv.End < resrv.Start)
                throw new ReservationDateConflict(resrv);
            Reservation conflictingReservtion = await _reservationConflicValidator.GetConflictReservation(resrv);
            if (conflictingReservtion != null)
                throw new ReservationConflictException(conflictingReservtion, resrv);
            await _reservationCreator.CreateReservation(resrv);
        }
    }
}
