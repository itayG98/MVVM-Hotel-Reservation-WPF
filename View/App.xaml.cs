using MVVM.Model;
using MVVM.Services;
using MVVM.Sores;
using MVVM.ViewModel;
using System;
using System.Windows;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;

        public App() 
        {
            _hotel = new Hotel("Gety's Suiets");
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
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
