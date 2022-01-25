using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Week7.WPF.Binding.Models;
using Week7.WPF.Binding.ViewModels;

namespace Week7.WPF.Binding
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //diamo le info di startup...
        protected override void OnStartup(StartupEventArgs e) //questo è proprio un evento: andranno eseguite queste operazioni
        {
            base.OnStartup(e); //roba della classe base

            //COLLEGAMENTO TRA INTERFACCIA DEL REPOSITORY E IMPLEMENTAZIONE DEL REPO CHE GESTISCE I DATI
            //stabiliamo qual è il repository corrispondente all'interfaccia IPersonRepository -> quale voglio usare
            IRepositoryPerson repositoryPerson = new RepositoryMockPerson();


            //VIEW MODEL DA UTILIZZARE NELL'APP
            //questa implementazione va legata al viewmodel, che aveva il _repoPerson come proprietà
            //-> glielo diamo in pasto al costruttore del VM
            MainWindowViewModel vm = new MainWindowViewModel(repositoryPerson);


            //FINESTRA CHE DEVE ESSERE VISUALIZZATA IN FASE DI STARTUP
            //serve quindi un costruttore che contenga il viewmodel associato alla view
            MainWindow window = new MainWindow(vm);

            //COMANDO PER MOSTRARE LA FINESTRA
            window.Show();
        }
    }
}
