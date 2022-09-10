using MVVM.Model;
using MVVM.Sores;
using MVVM.ViewModel;

namespace MVVM.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViwModel = new MakeReservationViewModel(new Hotel("Exmp"));
        }
    }
}
