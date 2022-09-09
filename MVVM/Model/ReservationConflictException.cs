using System;
using System.Runtime.Serialization;

namespace MVVM.Model
{
    /// <summary>
    /// The Exeption thrown for two Reservation which conflicts eachother
    /// </summary>
    [Serializable]
    internal class ReservationConflictException : Exception
    {
        public Reservation ExistingReservation { get; }
        public Reservation IncomingReservation { get; }


        public ReservationConflictException(Reservation existingReservation, Reservation incomingReservation)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationConflictException(string? message, Reservation existingReservation, Reservation incomingReservation) : base(message)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationConflictException(string? message, Exception? innerException, Reservation existingReservation, Reservation incomingReservation) : base(message, innerException)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public override string Message => $"{ExistingReservation.Start.ToString("d")}-{ExistingReservation.End.ToString("d")}" +
            $" in room: {ExistingReservation.roomID} already taken and conflicts the new order";
    }
}