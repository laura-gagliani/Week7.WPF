using Avanade.Allocation.WPF.Messaging.Employees;
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
    /// Interaction logic for EmployeeUpdate.xaml
    /// </summary>
    public partial class EmployeeUpdate : Window
    {
        public EmployeeUpdate()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseUpdateEmployeeMessage>(this, _ => Close());

            Closing += (s, e) =>
            { //eseguo la deregistrazione a tutti i messaggi a cui questa view è registrata?
              //scollego anche il view model per evitare conflitti con altre aperture di finestre

                Messenger.Default.Unregister(this);
                Messenger.Default.Unregister(DataContext);
            };
        }
    }
}
