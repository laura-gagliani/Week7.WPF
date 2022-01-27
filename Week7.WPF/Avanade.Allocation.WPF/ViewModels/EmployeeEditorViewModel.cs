using Avanade.Allocation.Core.BusinessLayer;
using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.Core.Repositories;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class EmployeeEditorViewModel : ViewModelBase
    {
        public ICommand CreateEmployeeCommand { get; set; }
        public ICommand LoadEmployeesCommand { get; set; } //questo non sarà attivato da un pulsante.. andrà da sé al caricamento della pagina

        public EmployeeEditorViewModel()
        {
            CreateEmployeeCommand = new RelayCommand(() => ExecuteCreateEmployee());
            LoadEmployeesCommand = new RelayCommand(() => ExecuteLoadEmployees());

            //inizializzazione delle liste
            _employeeSource = new ObservableCollection<EmployeeRowViewModel>();
            _employees = new CollectionView(_employeeSource);

            LoadEmployeesCommand.Execute(null);
        }

        

        //lista observable: che mostra le modifiche fatte sulla nostra lista
        public ObservableCollection<EmployeeRowViewModel> _employeeSource;

        //collection di veri e propri impiegati
        private ICollectionView _employees;
        public ICollectionView Employees
        {
            get { return _employees; }
            set { _employees = value; RaisePropertyChanged(); }
        }



        private void ExecuteLoadEmployees()
        {
            IEmployeeRepository repo = new MockEmployeeRepository();
            MainBusinessLayer layer = new MainBusinessLayer(repo);

            var employees = layer.FetchAllEmployees();

            //pulizia della lista, in caso che la finestra fosse già stata aperta o che
            _employeeSource.Clear();

            //per ogni employee creo una riga di tipo EmployeeRowViewModel
            foreach (Employee e in employees)
            {
                var vmEmployeeRow = new EmployeeRowViewModel(e);
                _employeeSource.Add(vmEmployeeRow);

            }
        }

        private void ExecuteCreateEmployee()
        {
            throw new NotImplementedException();
        }

    }
}
