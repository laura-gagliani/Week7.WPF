using Avanade.Allocation.Core.BusinessLayer;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.Core.Repositories;
using Avanade.Allocation.Core.Utils;
using Avanade.Allocation.WPF.Messaging.Misc;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Avanade.Allocation.WPF.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        //la classe da cui ereditiamo (dataci dal pacchetto mvvmlight) ha una serie di metodi che useremo...
        //per esempio la classe di RelayCommand sta già là (ha lo stesso significato/contenuto logico

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
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


        public RelayCommand SignInCommand { get; set; }

        public SignInViewModel()
        {
            SignInCommand = new RelayCommand(
                () => ExecuteSignIn(),
                () => CanExecuteSignIn());
            //if (IsInDesignMode)
            //{
            //    UserName = "nome.cognome";
            //    Password = "password";
            //}
            //else
            //{
            //    UserName = "mario.rossi";
            //    Password= "12345";
            //}
        }

        private bool CanExecuteSignIn()
        {
            return !string.IsNullOrEmpty(_userName) && !string.IsNullOrEmpty(_password);
        }

        private async Task ExecuteSignIn()
        {
            //inizializzo il BL
            IUserRepository repo = new MockUserRepository();
            AuthenticationBusinessLayer layer = new AuthenticationBusinessLayer(repo);

            //eseguo l'autenticazione (async) mediante il bl appena creato 
            Response response = await layer.SignInAsync(UserName, Password);
            if (response.Success)
            {
                //apri finestra di dialogo con contenuto 
                Messenger.Default.Send(new DialogMessage { Title = "Log-In Effettuato", Content = response.Message });
                Messenger.Default.Send(new ShowHomeViewMessage());
            }
            else
            {
                //finestra di dialogo con il messaggio
                Messenger.Default.Send(new DialogMessage { Title = "Log-In Effettuato", Content = response.Message });
                //TODO
            }
        }
    }
}
