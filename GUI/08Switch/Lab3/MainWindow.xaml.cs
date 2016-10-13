using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas mainCanvas;
        Circuit circuit;

        public MainWindow()
        {
            //InitializeComponent(); Not needed
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Title = "Switch Lab Part 3";
            mainCanvas = new Canvas();
            Content = mainCanvas;
            Height = 400.0;
            Width = 500.0;
            circuit = new Circuit(mainCanvas); ;
        }
    }
}
