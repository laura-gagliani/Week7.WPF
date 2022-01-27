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
    public class EmployeeUpdateViewModel : ViewModelBase
    {
        public ICommand EmployeeUpdateCommand { get; set; }

        public EmployeeUpdateViewModel(Employee e)
        {

            EmployeeUpdateCommand = new RelayCommand(ExecuteUpdateEmployee, CanExecuteUpdateEmployee);

            if (!IsInDesignMode)
            {
                //se è in esecuzione voglio che il PropertyChanged mi vada a triggerare il CanExecuteCreateEmployee
                PropertyChanged += (s, e) =>
                {
                    (EmployeeUpdateCommand as RelayCommand).RaiseCanExecuteChanged();
                };
            }

            FirstName = e.FirstName;
            LastName = e.LastName;
            Email = e.Email;
            Salary = e.Salary;
            DateOfBirth = e.DateOfBirth;
            _id = e.Id;

        }

        private bool CanExecuteUpdateEmployee()
        {
            //tutti i campi devono essere compilati
            return !string.IsNullOrEmpty(_firstName) &&
                !string.IsNullOrEmpty(_lastName) &&
                !string.IsNullOrEmpty(_email) &&
                !string.IsNullOrEmpty(Salary.ToString()) &&
                !string.IsNullOrEmpty(DateOfBirth.ToString());
        }

        private void ExecuteUpdateEmployee()
        {
            Employee updatedEmp = new Employee();
            updatedEmp.Id = _id;
            updatedEmp.FirstName = _firstName;
            updatedEmp.LastName = _lastName;
            updatedEmp.Email = _email;
            updatedEmp.Salary = _salary;
            updatedEmp.DateOfBirth = _dateOfBirth;
            updatedEmp.IsEnabled = true;

            MainBusinessLayer layer = new MainBusinessLayer(new MockEmployeeRepository());

            Response response = layer.UpdateEmployee(updatedEmp);

            if (!response.Success)
            {
                Messenger.Default.Send(new DialogMessage()
                {
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
            Messenger.Default.Send(new CloseUpdateEmployeeMessage());

        }


        private int _id;

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


    }
}
