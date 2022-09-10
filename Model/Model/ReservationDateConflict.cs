using System;


namespace MVVM.Model
{
    public class ReservationDateConflict : Exception
    {
        /// <summary>
        /// The Exeption thrown when a Reservation Dates are nto valid
        /// </summary>
        public Reservation Reservation { get; }

        public ReservationDateConflict(Reservation reservation)
        {

            Reservation = reservation;
        }
        public ReservationDateConflict(string message, Reservation reservation) : base(message)
        {
            Reservation = reservation;
        }
        public ReservationDateConflict(string message, Exception inner, Reservation reservation) : base(message, inner)
        {
            Reservation = reservation;
        }
        protected ReservationDateConflict(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public override string Message =>  $"The reservation dates {Reservation.Start}-{Reservation.End} are not valid";
    }

}

