using System;

namespace MVVM.Model
{
    public class Reservation
    {
        public  RoomID roomID { get; }
        public string UserName { get; }
        public  DateTime Start { get; }
        public  DateTime End { get; }
        public TimeSpan Duration => End.Subtract(Start);

        public Reservation(string userName, RoomID roomID, DateTime start, DateTime end)
        {
            UserName = userName;
            this.roomID = roomID;
            Start = start;
            End = end;
        }
        public override string ToString()
        {
            return $" {roomID}-{UserName}-{Start}-{End} ";
        }
    }
}
