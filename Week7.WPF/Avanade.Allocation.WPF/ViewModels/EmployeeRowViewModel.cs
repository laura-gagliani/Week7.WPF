using Avanade.Allocation.Core.BusinessLayer;
using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.WPF.Messaging.Employees;
using Avanade.Allocation.WPF.Messaging.Misc;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class EmployeeRowViewModel : ViewModelBase
    {
        private Employee _employee;
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged();  }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged(); }
        }


        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public EmployeeRowViewModel()
        {
            UpdateCommand = new RelayCommand(ExecuteUpdate);
            DeleteCommand = new RelayCommand(ExecuteDelete);

        }

        public EmployeeRowViewModel(Employee e) : this()  //segue comunque il costruttore vuoto!
        {
            //questo costruttore che piglia l'employee viene chiamato solo quando si riempie la lista nel LoadEmployee

            //associa il dipendente trovato (e annesse proprietà) e popola la view
            _employee = e;
            FirstName = e.FirstName;
            LastName = e.LastName;

        }

        private void ExecuteUpdate()
        {
            Messenger.Default.Send(new ShowUpdateEmployeeMessage()
            { 
                SelectedEmployee = _employee,
            }
        );
        }

        private void ExecuteDelete()
        {
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Warning",
                Content = "Confermi la cancellazione?",
                Icon = System.Windows.MessageBoxImage.Warning,
                Buttons = System.Windows.MessageBoxButton.YesNo,
                Callback = OnMessageBoxResultReceived

            });
        }

        private void OnMessageBoxResultReceived(MessageBoxResult clickResult)
        {
            if (clickResult == MessageBoxResult.Yes)
            {
                //inizializzo il bl per andare ad attivare la cancellazione
                var layer = new MainBusinessLayer(new MockEmployeeRepository());
                var response = layer.DeleteEmployee(_employee);

                if (!response.Success)
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Errore",
                        Content = response.Message,
                        Icon = MessageBoxImage.Error,
                        Buttons = MessageBoxButton.OK,
                    });
                    return;
                }
                else
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Deletion Confirmed",
                        Content = response.Message,
                        Icon = MessageBoxImage.Information,
                        Buttons = MessageBoxButton.OK,
                    });
                    return;
                }
            }
        }
    }
}