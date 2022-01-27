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
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : Window
    {
        public SignInView()
        {
            InitializeComponent();

            //questa finestra deve stare in ascolto...per messaggi di showhomeview -> a cui rispondere col metodo "onshowhomeviewmessageRECEIVED"
            Messenger.Default.Register<ShowHomeViewMessage>(this, OnShowHomeViewMessageReceived);
        }

        private void OnShowHomeViewMessageReceived(ShowHomeViewMessage message)
        {            
            //inizializzo la homeView e il suo viewmodel
            HomeView homeView = new HomeView();
            HomeViewModel homeVM = new HomeViewModel();

            homeView.DataContext = homeVM;

            //apro la nuova finestra e chiudo questa di signin
            homeView.Show();
            this.Close();
        }
    }
}
