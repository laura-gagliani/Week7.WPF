using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.WPF.Esercizio2ECommerce.Models;

namespace Week7.WPF.Esercizio2ECommerce.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        private IProductRepository _productRepository;


        public MainWindowVM(IProductRepository productRepo)
        {
            _productRepository = productRepo;
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
            }

        }


        private double _totalCartAmount = 0;
        public double TotalCartAmount
        {
            get => _totalCartAmount;
            set => _totalCartAmount = value;
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

    }
}
