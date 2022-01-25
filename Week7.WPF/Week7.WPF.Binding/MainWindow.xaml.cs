﻿using System;
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
using Week7.WPF.Binding.ViewModels;

namespace Week7.WPF.Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;   //così gli dico "guarda, la finestra di startup deve prendere i dati che ti dice il VM che ti è assegnato"
            //è grazie a questo collegamento che lato xaml gli posso dire ItemSource Binding Path... tale entità
        }

    }
}
