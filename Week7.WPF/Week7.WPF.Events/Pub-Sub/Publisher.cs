using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Events.Pub_Sub
{
    public class Publisher
    {
        //2

        public string PublisherName { get; set; }

        public Publisher(string publisherName)
        {
            PublisherName = publisherName;
        }

        //EVENTO, membro della classe stessa, a cui i subscriber si iscriveranno
        //dichiarazione:

        public event Notify OnPublish;

        //questo notify è un DELEGATO, un metodo, che deve seguire il trigger dell'evento
        //gli possiamo dare una firma da rispettare:

        public delegate void Notify(Publisher p, Notification notification);

        // una volta triggerato l'evento io quindi posso specificare l'azione che deve essere assolta
        //questo metodo in particolare prende come parametri il publisher e la notifica (da noi definita) che deve dare

        //specifichiamo anche il metodo che effettivamente pubblica l'evento stesso:
        public void Publish()
        {
            //se l'evento è scatenato deve creare un oggetto di tipo Notification...

            if (OnPublish != null) //è diverso da null se c'è stata una pubblicazione
            {
                Notification n = new Notification(DateTime.Now, $"Notifica da parte di {PublisherName} ");

                //poi richiamiamo l'evento OnPublish... realizzato attraverso il delegate corrispondente
                //(che quindi come parametri vuole il publisher scatenante (this, questa classe in cui siamo) 
                // e la notifica appena creata

                OnPublish(this, n);
            }
        }

        //a questo punto resta solo il Subscriber, quello che vuole ricevere questi messaggi/sottoscrivere all'evento
    }
    
}
