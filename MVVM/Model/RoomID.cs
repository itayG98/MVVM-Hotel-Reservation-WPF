using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class RoomID
    {
        public int FloorNum { get; }
        public int RoomNum { get; }
        public RoomID(int floorNum, int roomNum)
        {
            FloorNum = floorNum;
            RoomNum = roomNum;
        }

        public override bool Equals(object? other)
        {
            if (other is RoomID otherRoomID)
                return otherRoomID.FloorNum == FloorNum && otherRoomID.RoomNum == RoomNum;
            return false;
        }

        public override int GetHashCode()=> HashCode.Combine(FloorNum, RoomNum);

        public override string ToString()=> $"{RoomNum}-{FloorNum}";

        public static bool operator ==(RoomID roomID1, RoomID roomID2)
        {
            if (roomID1 is null && roomID2 is null)
                return true;
            return !(roomID1 is null)&& roomID1.Equals(roomID2);
        }
        public static bool operator !=(RoomID roomID1 ,RoomID roomID2) =>  !(roomID1 ==roomID2);

    }
}
