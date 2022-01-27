using Avanade.Allocation.WPF.Messaging.Employees;
using Avanade.Allocation.WPF.Messaging.Misc;
using Avanade.Allocation.WPF.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Avanade.Allocation.WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            //qui dobbiamo iscriverci al messaggio che dice "apri la finestra employees"
            Messenger.Default.Register<ShowEmployeesMessage>(this, OnShowEmployeesMessageReceived);

            InitializeComponent();
        }

        private void OnShowEmployeesMessageReceived(ShowEmployeesMessage message)
        {
            // inizializza view e viewmodel per la nuova roba da mostrare e apre la finestra
            EmployeeEditorView empEditorView = new EmployeeEditorView();
            EmployeeEditorViewModel empEditorVM = new EmployeeEditorViewModel();
            empEditorView.DataContext = empEditorVM;

            empEditorView.Show();
        }
    }
}
