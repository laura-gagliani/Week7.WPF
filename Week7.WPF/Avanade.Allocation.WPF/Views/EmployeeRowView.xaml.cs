using Avanade.Allocation.Core.Entities;
using Avanade.Allocation.WPF.Messaging.Employees;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Avanade.Allocation.WPF.Views
{
    /// <summary>
    /// Interaction logic for EmployeeRowView.xaml
    /// </summary>
    public partial class EmployeeRowView : UserControl
    {
        public EmployeeRowView()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowUpdateEmployeeMessage>(this, OnShowUpdateEmployeeMessageReceived);
        }

        private void OnShowUpdateEmployeeMessageReceived(ShowUpdateEmployeeMessage message)
        {
            Employee e = message.SelectedEmployee;

            EmployeeUpdate updateView = new EmployeeUpdate();
            EmployeeUpdateViewModel updateVM = new EmployeeUpdateViewModel(e);
            updateView.DataContext = updateVM;

            updateView.Show();
        }
    }
}
