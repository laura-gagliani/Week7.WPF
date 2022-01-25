using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.AppBase.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //qui ci vanno tutti gli elementi che nella View devono essere raggiungibili con il binding

        private string _myProperty = "testo di prova";
        public string MyProperty
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Get myprop1");
                return _myProperty;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine("Set myprop2");
                _myProperty = value; //il valore prelevato dalla view... che va nel campo privato
                NotifyPropertyChanged();
            }
        }


        private int _myProperty2;
        public int MyProperty2
        {
            get
            {
                return _myProperty2;
            }
            set
            {
                _myProperty2 = value;
            }
        }


        //seconda parte: Checkbox + Date
        private bool _isChecked = true;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; NotifyPropertyChanged(); }
        }
    }
}
