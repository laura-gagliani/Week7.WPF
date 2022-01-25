using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Week7.WPF.Binding.Models;

namespace Week7.WPF.Binding.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //questa conterrà quindi tutte le info necessarie per gestire quello che c'è nella vista...

        //obiettivo:
        //noi vorremmo visualizzare la lista dei cognomi nella combobox e poi
        //vedere una specie di testo/messaggio contenente il saluto per la persona specifica


        //quindi qui va di sicuro indicata la lista di persone, il repo, che sta nel Model
        //questa diventa la ItemSource necessaria per il binding?

        private IRepositoryPerson _repoPerson;

        //POST_-AGGIUNTA RELAYCOMMAND
        public RelayCommand WelcomeCommand { get; private set; }
        //voglio fare in modo che il mio comando non sia modificabile dall'esterno


        //importato dall'interfaccia:
        public event PropertyChangedEventHandler? PropertyChanged;


        //lista di persone da collegare in Binding con la View:
        public IList<Person> People => _repoPerson.GetAll();
        //questo tipo di dicitura corrisponde al Get:
        //public IList<Person> People
        //{
        //    get
        //    {
        //        return _repoPerson.GetAll();
        //    }
        //}
        //la freccia della lambda corrisponde ad un "return" più stringato !!

        //dobbiamo poi specificare un campo corrispondente alla persona selezionata:
        //serve al ViewModel per gestire la possibilità della View di selezionare una persona
        //la proprietà/campo deve essere privata... e poi una corrispondente proprietà public con i metodi get e set!

        private Person _selectedPerson = null; // la inizializziamo a null
        public Person SelectedPerson
        {
            //corrispondente prop. pubblica, "esposta" all'esterno, che rende la person privata
            //lo si fa per una questione di protezione...
            //potremmo avere per esempio la SelectedPerson senza il get, che non può essere restituita
            //è un modo per raffinare il comportamento get e set delle proprietà

            get => _selectedPerson;
            //settare la proprietà: abilitare il binding
            set
            {
                if (_selectedPerson == value) //se la persona selezionata è già selezionata...
                {
                    return; // gli dico esci, vanno evitate tutte delle casistiche di ridondanza...
                }
                _selectedPerson = value; //solo in caso contrario vai a "selezionarla", a settare il campo privato!

                //poi scateniamo l'evento di binding
                NotifyPropertyChanged();
                //richiamiamo l'operazione da eseguire quando la proprietà viene modificata (il nostro "OnNotificationReceived")
                WelcomeCommand.RaiseCanExecuteChanged();

            }


        }

        private string _txtWelcome = null;
        public string TxtWelcome
        {
            get => _txtWelcome;
            set
            {
                _txtWelcome = value;
                //per far sì di avere il binding a due vie richiama l'esecuzione dell'evento:
                NotifyPropertyChanged(); //avendo utilizzato il callerMemberName non devo passargli la proprietà modificata come param
            }
        }


        public MainWindowViewModel(IRepositoryPerson repositoryPerson)
        {
            _repoPerson = repositoryPerson;
            WelcomeCommand = new RelayCommand(WelcomeExecute, WelcomeCanExecute);
        }

        //fatto questo avremo bisogno dell'evento di notifica... che sta sempre nel view model
        //(il metodo che viene richiamato al click del bottone)
        public void Welcome()
        {
            if (SelectedPerson != null)
            {
                TxtWelcome = $"Ciao {SelectedPerson}";
            }
        }

        //metodi scritti post aggiunta RelayCommand:
        private bool WelcomeCanExecute(object param) // questo è il metodo che mi dice se posso eseguire Welcome o meno
        {
            return SelectedPerson != null;  //rendo true se SelectedPerson è diverso da null
        }

        private void WelcomeExecute(object param) // e questo è il metodo che esegue il Welcome (semplicemente lo richiama)
        {
            Welcome();
        }

        //post aggiunta interfaccia; noi dobbiamo mettere il metodo che gestisce il cambio della proprietà...
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //questo caller fa sì che sia il compilatore ad accorgersi da sé cosa è cambiato!
            // l' ="" è il default... lui così va a vedersi tutte le proprietà che possono essere state modificate

            //richiamo l'evento PropertyChanged importato dall'interfaccia
            //questo andrà a gestire tramite i comandi cosa deve succedere alla modifica della proprietà
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
