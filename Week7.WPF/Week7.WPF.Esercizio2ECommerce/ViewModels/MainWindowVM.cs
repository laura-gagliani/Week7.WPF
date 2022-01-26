using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.WPF.Esercizio2ECommerce.Commands;
using Week7.WPF.Esercizio2ECommerce.Models;

namespace Week7.WPF.Esercizio2ECommerce.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        private IProductRepository _productRepository;
        public RelayCommand AddCartTotalCommand { get; private set; }

        public MainWindowVM(IProductRepository productRepo)
        {
            _productRepository = productRepo;
            AddCartTotalCommand = new RelayCommand(AddCartTotalExecute, AddCartTotalCanExecute);
            //è corretto avere sia execute che can execute. can execute poteva essere lo stesso anche per l'altro bottone
        }

       
        //proprietà lista prodotti
        public IList<Product> Products => _productRepository.FetchAll();


        private Product _selectedProduct = null;
        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                NotifyPropertyChanged();
                AddCartTotalCommand.RaiseCanExecuteChanged();
            }

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
                NotifyPropertyChanged();
            } 
        }

        private bool _isChecked = false;
        public bool IsChecked
        {
            get => _isChecked;
            set
            { 
                _isChecked = value;
                NotifyPropertyChanged();
            }
        }

        public void AddCartTotal()
        {
            if (SelectedProduct != null)
            {
                _totalCartAmount += SelectedProduct.Price;
                NotifyPropertyChanged();
                TxtCartAmount = _totalCartAmount.ToString();
                //qui lei sommava la prop numerica e poi modificava il TxtCart. dalla main window si traccia il TxtCart, non il numerico
            }
        }


        private void AddCartTotalExecute(object obj)
        {
            AddCartTotal();
        }

        private bool AddCartTotalCanExecute(object obj)
        {
            return SelectedProduct != null; 
        }
    }
}
