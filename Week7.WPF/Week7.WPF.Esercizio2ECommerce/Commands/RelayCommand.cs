using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Week7.WPF.Esercizio2ECommerce.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;


        private Action<object> executeMethod;
        private Predicate<object> canExecuteMethod;



        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
