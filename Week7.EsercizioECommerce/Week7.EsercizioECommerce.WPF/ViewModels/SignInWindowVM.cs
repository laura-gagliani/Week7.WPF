using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.EsercizioECommerce.Core.BusinessLayers;
using Week7.EsercizioECommerce.Core.Mock.Repositories;
using Week7.EsercizioECommerce.Core.Repositories;
using Week7.EsercizioECommerce.Core.Utils;
using Week7.EsercizioECommerce.WPF.Messaging.Misc;

namespace Week7.EsercizioECommerce.WPF.ViewModels
{
    public class SignInWindowVM : ViewModelBase
    {
        public RelayCommand SignInCommand { get; set; }

        public SignInWindowVM()
        {
            SignInCommand = new RelayCommand(
                () => ExecuteSignIn(),
                () => CanExecuteSignIn());
        }



        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged();
                SignInCommand.RaiseCanExecuteChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
                SignInCommand.RaiseCanExecuteChanged();
            }
        }


        private bool CanExecuteSignIn()
        {
            return !string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password);
        }

        private async Task ExecuteSignIn()
        {
            IUserRepository repo = new MockUserRepository();
            AuthenticationBusinessLayer layer = new AuthenticationBusinessLayer(repo);

            Response response = await layer.SignInAsync(Username, Password);
            if (response.Success)
            {
                //apri finestra di dialogo con contenuto 
                Messenger.Default.Send(new DialogMessage { Title = "Log-In Effettuato", Content = response.Message });
            }
            else
            {
                //finestra di dialogo con il messaggio
                Messenger.Default.Send(new DialogMessage { Title = "Log-In errato", Content = response.Message });
                //TODO
            }
        }
    }
}
