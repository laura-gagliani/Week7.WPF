using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.EsercizioECommerce.Core.Entities;
using Week7.EsercizioECommerce.Core.Repositories;
using System.Windows.Input;
using Week7.EsercizioECommerce.Core.Mock.Repositories;

namespace Week7.EsercizioECommerce.WPF.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        //lista prodotti
        IProductRepository _repo = new MockProductRepository();
        public IList<Product> Products => _repo.FetchAll();

        //comandi
        public RelayCommand AddCartTotalCommand { get; set; }
        public RelayCommand ShowDetailsCommand { get; set; }    

        public MainWindowVM()
        {
            AddCartTotalCommand = new RelayCommand(AddCartTotalExecute, CanExecute);
            ShowDetailsCommand = new RelayCommand(() => ShowDetailsExecute(), () => CanExecute());
            //è corretto avere sia execute che can execute. can execute poteva essere lo stesso anche per l'altro bottone
        }
                         

        private Product _selectedProduct = null;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                RaisePropertyChanged();
                AddCartTotalCommand.RaiseCanExecuteChanged();
                ShowDetailsCommand.RaiseCanExecuteChanged();
            }

        }

        private string _productDetails = null;
        public string ProductDetails
        {
            get { return _productDetails; }
            set { _productDetails = value; RaisePropertyChanged(); }
        }

        //per il totale del carrello ha una prop string, la stampa, con notify property changed,
        //e una private double con l'amount numerico inizializzato a zero.

        private double _totalCartAmount = 0;
        public double TotalCartAmount
        {
            get => _totalCartAmount;
            set
            {
                _totalCartAmount = value;
            }
        }


        private string _txtCartAmount = null;
        public string TxtCartAmount
        {
            get => _txtCartAmount;
            set
            {
                _txtCartAmount = value;
                RaisePropertyChanged();
            }
        }


        private bool _showCartCheck = false;
        public bool ShowCartCheck
        {
            get => _showCartCheck;
            set
            {
                _showCartCheck = value;
                RaisePropertyChanged();
            }
        }


        public void AddCartTotal()
        {
            if (SelectedProduct != null)
            {
                _totalCartAmount += SelectedProduct.Price;
                RaisePropertyChanged();
                TxtCartAmount = _totalCartAmount.ToString();
                //qui lei sommava la prop numerica e poi modificava il TxtCart. dalla main window si traccia il TxtCart, non il numerico
            }
        }


        private bool CanExecute()
        {
            return SelectedProduct != null;
        }

        private void AddCartTotalExecute()
        {
            AddCartTotal();
        }

        private void ShowDetailsExecute()
        {
            if (SelectedProduct != null)
            {
                ProductDetails = SelectedProduct.ToString();
                RaisePropertyChanged();

            }

        }

    }
}
