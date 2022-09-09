using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnProperyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            PropertyChanged.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
