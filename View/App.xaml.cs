using Hotel_Model.DBContext;
using Hotel_Model.Services.ReservationConflictValidator;
using Microsoft.EntityFrameworkCore;
using MVVM.Model;
using MVVM.Services;
using MVVM.Sores;
using MVVM.ViewModel;
using System;
using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Markup;
using ViewModel.Services.ReservationCreator;
using ViewModel.Services.ReservationProvider;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
        private const string CONNECTIONSTRING= "Data Source = itayG98; Initial Catalog = Hotel; Integrated Security = True";
        private readonly ReserveRoomDbFactory reservationDbContextFactort;
        public App() 
        {
            reservationDbContextFactort = new (CONNECTIONSTRING);
            DatabaseReservationProvider reservationProvider = new (reservationDbContextFactort);
            DatabaseReservationCreator reservationCreator = new (reservationDbContextFactort);
            DatabaseReservationConflictValidator reservationValidator = new (reservationDbContextFactort);

            ReservationBook reservationBook = new (reservationProvider, reservationCreator, reservationValidator);
            _hotel = new ("Gety's Suiets",reservationBook);
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
            return new MakeReservationViewModel(_hotel,new NavigationService(_navigationStore, CreateReservationLVViewModel));
        }

        private ReservationLVViewModel CreateReservationLVViewModel()
        {
            return ReservationLVViewModel.LoadViewModel(_hotel,new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
