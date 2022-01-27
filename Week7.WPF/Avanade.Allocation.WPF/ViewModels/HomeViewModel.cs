using Avanade.Allocation.WPF.Messaging.Employees;
using Avanade.Allocation.WPF.Messaging.Misc;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand ExitCommand { get; set; }
        public ICommand ShowEmployeesCommand { get; set; }

        public HomeViewModel()
        {
            ExitCommand = new RelayCommand( () => ExecuteExit() );
            ShowEmployeesCommand = new RelayCommand( ()=> ExecuteShowEmployees() );
            
        }

        private void ExecuteShowEmployees()
        {
            Messenger.Default.Send(new ShowEmployeesMessage());
        }

        private void ExecuteExit()
        {
            Messenger.Default.Send(new DialogMessage { Title = "Exit", Content = "Confermi?", 
                                   Icon = MessageBoxImage.Question, Buttons = MessageBoxButton.YesNo, 
                                    Callback = (result) =>
                                    {
                                        if (result == MessageBoxResult.Yes)
                                            Messenger.Default.Send(new ShutDownApplicationMessage());
                                        //TODO FIX

                                    }
                                   });
        }
    }
}
