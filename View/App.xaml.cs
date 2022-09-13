using Hotel_Model.DBContext;
using Hotel_Model.Services.ReservationConflictValidator;
using Microsoft.EntityFrameworkCore;
using MVVM.Model;
using MVVM.Services;
using MVVM.Sores;
using MVVM.ViewModel;
using System.Configuration;
using System.Windows;
using ViewModel.Services.ReservationCreator;
using ViewModel.Services.ReservationProvider;
using ViewModel.Sores;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly Hotel _hotel;
        private readonly HotelStore _hotelStore;
        private readonly NavigationStore _navigationStore;
        private readonly string _connectionString;

        private readonly ReserveRoomDbFactory reservationDbContextFactort;
        public App() 
        {
            //Get the configured  connString
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            _connectionString = settings[0].ConnectionString;
            reservationDbContextFactort = new (_connectionString);

            //Create services of the app
            DatabaseReservationProvider reservationProvider = new (reservationDbContextFactort);
            DatabaseReservationCreator reservationCreator = new (reservationDbContextFactort);
            DatabaseReservationConflictValidator reservationValidator = new (reservationDbContextFactort);

            //Inti hotel with the services and navigation store
            ReservationBook reservationBook = new (reservationProvider, reservationCreator, reservationValidator);
            _hotel = new ("Gety's Suiets",reservationBook);
            _hotelStore = new HotelStore(_hotel);
            _navigationStore = new();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (ReserveRoomDBContext dbcContext = reservationDbContextFactort.CreateDbContext())
            {
                dbcContext.Database.Migrate();
            }
            
            _navigationStore.CurrentViewModel = CreateMakeReservationViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotelStore, new NavigationService(_navigationStore, CreateReservationLVViewModel));
        }

        private ReservationLVViewModel CreateReservationLVViewModel()
        {
            return ReservationLVViewModel.LoadViewModel(_hotelStore, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
