using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("Singelton Suites");
            try
            {
                hotel.MakeReserbation(new Reservation("Itay", new RoomID(1, 1), new DateTime(2022, 1, 1), new DateTime(2022, 1, 10)));
                hotel.MakeReserbation(new Reservation("Itay", new RoomID(1, 1), new DateTime(2022, 2, 1), new DateTime(2022, 2, 10)));
                hotel.MakeReserbation(new Reservation("Shon", new RoomID(2, 1), new DateTime(2022, 2, 1), new DateTime(2022, 2, 10)));
                hotel.MakeReserbation(new Reservation("Shon", new RoomID(2, 2), new DateTime(2022, 2, 12), new DateTime(2022, 2, 14)));
                hotel.MakeReserbation(new Reservation("Shon", new RoomID(2, 2), new DateTime(2022, 1, 1), new DateTime(2022, 1, 7)));
            }
            catch (ReservationConflictException ex)
            {
                MessageBox.Show($"{ex.ExistingReservation } Conflicts with {ex.IncomingReservation} ", "Error");
            }
            IEnumerable<Reservation> reservations = hotel.GetReservationsForUser("Itay");
            base.OnStartup(e);
        }
    }
}
