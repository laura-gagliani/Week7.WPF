using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Week7.WPF.Binding
{
    public class RelayCommand : ICommand
    {
        //implementiamo l'interfaccia:
        //- event handler per gestire i cambiamenti tra "può essere eseguito"/"non può"
        //- can execute, che verifica se l'operazione può essere eseguita
        //- execute, contentente parametri per l'esecuzione del comando stesso

        //a questi aggiungiamo due componenti: metodi che utilizzano un particolare delegate
        //Action è un delegato per metodi che non rendono niente
        //Predicate è un metodo che prende in input sempre un object, e restituisce un booleano
        //  (se l'oggetto rispetta tutta una serie di caratteristiche da noi definite nel metodo)

        //ci serviranno per indicare quali metodi devono essere eseguiti come controllo e come esecuzione del comando

        public event EventHandler? CanExecuteChanged;
        //PUNTATORE AD UN METODO CHE ESEGUE IL COMANDO RICHIESTO
        private Action<object> executeMethod;
        //PUNTATORE AD UN METODO CHE RENDE TRUE/FALSE IN BASE AL FATTO CHE SIANO RISPETTATE DETERM. CONDIZIONI 
        private Predicate<object> canExecuteMethod;

        //      avrei anche potuto scrivere
        //      private Func<object, bool> canExecuteMethod2;
        //      è lo stesso concetto del Predicate con una sintassi diversa
        //      in linq Func funziona allo stesso modo 

        //CHE NE FACCIAMO DI QUESTI DELEGATE?
        //li istanziamo quando viene creato il RelayCommand:
        public RelayCommand(Action<object> Execute, Predicate<object> CanExecute)
        {
            executeMethod = Execute;
            canExecuteMethod = CanExecute;

        }

        //praticamente gli stiamo dicendo...

        public bool CanExecute(object? parameter)
        {
            if (canExecuteMethod == null)
            {
                return true; // se non è stato istanziato il metodo canExecuteMethod questo comando(es. il tasto) sarà sempre abilitato
            }
            //altrimenti- se esiste un metodo istanziato - ovvero se ci sono casi in cui il comando deve essere attivo o disattivo (gestiti dal metodo)....
            return canExecuteMethod.Invoke(parameter);

            //oppure tutto stringato, con operatore ternario:
            //return (canExecuteMethod == null) ? true : canExecuteMethod.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            //vado a richiamare il metodo puntato..?
            executeMethod?.Invoke(parameter);

            //che è come dire
            //    if (Execute != null)
            //    {
            //        executeMethod.Invoke(parameter);
            //    }
        }

        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty); // vado ad invocare CanExecuteChanged, che non si porta dietro nessun argomento (quindi Empty)
        }
    }
}
