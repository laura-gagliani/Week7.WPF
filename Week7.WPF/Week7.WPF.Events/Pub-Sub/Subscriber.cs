using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.Events.Pub_Sub
{
    public class Subscriber
    {
        //3

        public string SubscriberName { get; set; }

        public Subscriber(string name)
        {
            SubscriberName = name;  
        }

        //a questo punto nel nostro sottoscrittore ci serve:
        //- un metodo per ISCRIVERSI 
        //- un metodo per DISISCRIVERSI
        //- un metodo per gestire la ricezione dell'evento da parte del publisher

        public void Subscribe(Publisher p)
        {
            p.OnPublish += OnNotificationReceived;
            //sto dicendo che:
            //preso il publisher, preso un evento che lui scatena, voglio che venga eseguito il metodo del subscriber
        }

        public void Unsubscribe(Publisher p)
        {
            p.OnPublish -= OnNotificationReceived;  
            //non voglio più che il nostro metodo OnNotificationReceived "risponda" al trigger della pubblicazione!
        }


        // Metodo per RICEZIONE della notifica:
        protected virtual void OnNotificationReceived(Publisher p, Notification n)
        {
            //questo metodo ha la stessa firma del metodo delegato Notify che abbiamo nel Publisher!
            //deve essere dello "stesso tipo", deve combaciare. come mai?
            //a scatenamento dell'evento X si recupera la lista dei sottoscrittori a quell'evento, e si lanciano i loro metodi X
            //perché ovviamente sono quelli "consoni" alla gestione dell'evento X. 

            Console.WriteLine($"Hi {SubscriberName}! \n{n}");
        }

    }
}
