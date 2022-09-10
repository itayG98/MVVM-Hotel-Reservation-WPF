using MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVM.Sores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViwModel;
        public event Action CurrentViewModelChanged;

        public ViewModelBase CurrentViwModel 
        {
            get => _currentViwModel;
            set
            {
                _currentViwModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
