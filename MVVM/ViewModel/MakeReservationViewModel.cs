using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class MakeReservationViewModel : ViewModelBase
    {
        private string _userName;
        private int roomID, floorNum;
        private DateTime start, end;
        public string UserName 
        {
            get {return _userName; }
            set {
                _userName = value;
                OnProperyChanged(nameof(UserName));
                } 
        }
        public int RoomID
        {
            get { return roomID; }
            set
            {
                roomID = value;
                OnProperyChanged(nameof(RoomID));
            }
        }
        public int FloorNum
        {
            get { return floorNum; }
            set
            {
                floorNum = value;
                OnProperyChanged(nameof(FloorNum));
            }
        }
        public DateTime StartDate
        {
            get { return start; }
            set
            {
                start = value;
                OnProperyChanged(nameof(StartDate));
            }
        }       
        public DateTime EndDate
        {
            get { return end; }
            set
            {
                end = value;
                OnProperyChanged(nameof(EndDate));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
    }
}
