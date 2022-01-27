using Avanade.Allocation.Core.BusinessLayer;
using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.Core.Utils;
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
    public class EmployeeCreateViewModel : ViewModelBase
    {
        public ICommand CreateEmployeeCommand { get; set; }

        public EmployeeCreateViewModel()
        {
            CreateEmployeeCommand = new RelayCommand(ExecuteCreateEmployee, CanExecuteCreateEmployee);

            if (!IsInDesignMode)
            {
                //se è in esecuzione voglio che il PropertyChanged mi vada a triggerare il CanExecuteCreateEmployee
                PropertyChanged += (s, e) =>
                {
                    (CreateEmployeeCommand as RelayCommand).RaiseCanExecuteChanged();
                };
            }
        }



        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged(); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(); }
        }

        private double _salary;
        public double Salary
        {
            get { return _salary; }
            set { _salary = value; RaisePropertyChanged(); }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; RaisePropertyChanged(); }
        }



        private void ExecuteCreateEmployee()
        {
            //recupero i dati dal viewmodel e creo una nuova entità employee
            Employee newEmployee = new Employee();
            {
                newEmployee.FirstName = FirstName;
                newEmployee.LastName = LastName;
                newEmployee.Email = Email;
                newEmployee.Salary = Salary;
                newEmployee.DateOfBirth = DateOfBirth;
                newEmployee.IsEnabled = true;
            }

            var layer = new MainBusinessLayer(new MockEmployeeRepository());
            Response response = layer.CreateEmployee(newEmployee);

            if (!response.Success)
            {
                Messenger.Default.Send(new DialogMessage() {
                    Title = "Error",
                    Content = response.Message,
                    Icon = MessageBoxImage.Error

                });
            }
            else
            {
                Messenger.Default.Send(new DialogMessage()
                {
                    Title = "",
                    Content = response.Message,
                    Icon = MessageBoxImage.Information

                });

            }
            Messenger.Default.Send(new CloseCreateEmployeeMessage());
        }

        private bool CanExecuteCreateEmployee()
        {
            //tutti i campi devono essere compilati
            return !string.IsNullOrEmpty(_firstName) &&
                !string.IsNullOrEmpty(_lastName) &&
                !string.IsNullOrEmpty(_email) &&
                !string.IsNullOrEmpty(Salary.ToString()) &&
                !string.IsNullOrEmpty(DateOfBirth.ToString());
        }
    }
}
