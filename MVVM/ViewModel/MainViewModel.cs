using MVVM.Commands;
using MVVM.Model;
using MVVM.Sores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViwModel;
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }


    }
}
