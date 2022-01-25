// See https://aka.ms/new-console-template for more information
using Week7.WPF.Events.Pub_Sub;


// 1
//ci servono prima di tutto Publisher, Subscriber e un oggetto(un "tipo" che faccia da Notifica)


//4

//Creazione dei Publisher
Publisher youtube = new Publisher("youtube.com");
Publisher instagram = new Publisher("Instagram");

//creazione dei subscribers
Subscriber sub1 = new Subscriber("Antonia");
Subscriber sub2 = new Subscriber("Renata");
Subscriber sub3 = new Subscriber("Alessandra");

//iscrizione:
sub1.Subscribe(youtube);
sub2.Subscribe(youtube);

sub1.Subscribe(instagram);
sub3.Subscribe(instagram);

//qualora quindi il nostro publisher dovesse mandare qualcosa ricevono la notifica solo gli iscritti!
//in questo caso, nella console app, il trigger sarà il nostro richiamare manualmente l'evento di publishing
//qui non abbiamo bottoni da pigiare... sennò nelle WPF ovviamente sarebbe il click o la pressione di tasti

youtube.Publish();  //corrispondente al click del mouse, per esempio

Console.WriteLine("--------------------");

instagram.Publish(); 

Console.WriteLine("--------------------");


Console.WriteLine("Simuliamo la disiscrizione dall'evento youtube per Antonia..."  ); 
sub1.Unsubscribe(youtube);



youtube.Publish();  //corrispondente al click del mouse, per esempio

Console.WriteLine("--------------------");

instagram.Publish();

Console.WriteLine("--------------------");

//torniamo all'es di ieri.. Ese1Soluzione

//ViewProduct è il corrispondente del nostro OnNotificationReceived.. ha come oggetti il sender (=Publisher) e l'argomento/evento EventArgs

//il bottone ha l'evento click ->
//Click="ViewProduct" non è altro che la sottoscrizione del metodo ViewProduct all'evento Click del publisher Button!!

