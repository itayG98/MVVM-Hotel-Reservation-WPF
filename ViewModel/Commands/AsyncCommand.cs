using MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Commands
{
    public abstract class AsyncCommand : CommandBase
    {
        private bool _isExecuting;
        private bool IsExcuting {
            get => _isExecuting;
            set 
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            } 
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExcuting&& base.CanExecute(parameter);
        }

        public override async void Execute(object? parameter) 
        {
            IsExcuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            finally 
            {
                IsExcuting = false;
            }
        }
        public abstract Task ExecuteAsync(object parameter);

    }
}
