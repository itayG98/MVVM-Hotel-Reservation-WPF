using Hotel_Model.DBContext;
using Microsoft.EntityFrameworkCore;
using MVVM.Model;
using MVVM.Services;
using MVVM.Sores;
using MVVM.ViewModel;
using System;
using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Markup;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
        private const string CONNECTIONSTRING= "Data Source = itayG98; Initial Catalog = HotelDB.db; Integrated Security = True";
        public App() 
        {
            _hotel = new Hotel("Gety's Suiets");
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(CONNECTIONSTRING).Options;
            ReserveRoomDBContext dbcContext = new ReserveRoomDBContext(options);
            dbcContext.Database.Migrate();
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
            return new ReservationLVViewModel(_hotel,new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
