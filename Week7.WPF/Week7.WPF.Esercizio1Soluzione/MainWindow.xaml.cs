using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Week7.WPF.Esercizio1Soluzione.Models;

namespace Week7.WPF.Esercizio1Soluzione
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {           
        //adesso noi leghiamo View e Model, ma un domani questo non andrà fatto
        private IProductsRepository productRepository = new ProductRepositoryMock();

        public MainWindow()
        {
            InitializeComponent();
            lstProducts.ItemsSource = productRepository.GetAll().Select(p=> p.Name);
        }

        private void ViewProduct(object sender, RoutedEventArgs e)
        {
            var selectedName = lstProducts.SelectedItem;
            if (lstProducts.SelectedItem != null)
            {
                Product product = productRepository.GetAll().SingleOrDefault(p=> p.Name.Equals(selectedName));
                txtProductDetails.Text = product.ToString();    
            }
        }
    }
}
