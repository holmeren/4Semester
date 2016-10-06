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
using I4GUI;
using System.Drawing;


namespace AgentOpgave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Agents myAgents = new Agents();

        public MainWindow()
        {
            InitializeComponent();
         



        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != 0)
                listBox.SelectedIndex--;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != listBox.Items.Count)
                listBox.SelectedIndex++;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            myAgents.Add(new Agent());
            listBox.SelectedIndex = listBox.Items.Count - 1;
        }

      
    }

}