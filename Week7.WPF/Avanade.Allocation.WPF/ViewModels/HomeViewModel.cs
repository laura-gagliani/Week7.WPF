using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ICommand ExitCommand { get; set; }
        private ICommand ShowEmployeesCommand { get; set; }

        public HomeViewModel()
        {
            ExitCommand = new RelayCommand( () => ExecuteExit() );
            ShowEmployeesCommand = new RelayCommand( ()=> ExecuteShowEmployees() );
            
        }

        private void ExecuteShowEmployees()
        {
            throw new NotImplementedException();
        }

        private void ExecuteExit()
        {
            throw new NotImplementedException();
        }
    }
}
