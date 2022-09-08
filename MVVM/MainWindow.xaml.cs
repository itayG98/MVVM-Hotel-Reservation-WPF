using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Hotel hotel = new Hotel("Singelton Suites");

        public List<Reservation> AllReservations 
        {
            get {return hotel.GetReservations().ToList(); }
            set {; } 
        }
        public MainWindow()
        {
            InitializeComponent();
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
                MessageBox.Show($"{ex.ExistingReservation} Conflicts with {ex.IncomingReservation} ", "Error");
            }
            IEnumerable<Reservation> reservations = hotel.GetReservations();

        }
    }
}
