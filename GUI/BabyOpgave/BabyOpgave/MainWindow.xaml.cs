using System;
using System.Collections.Generic;
using System.IO;
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

namespace BabyOpgave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<string> myCollection;
        private List<BabyName> babyList;
        private List<int> decadeList;
        public MainWindow()
        {
            InitializeComponent();
            for(int i = 1900; i < 2010; i += 10)
            {
                decadeList.Add(i);
            }
            listBox1.ItemsSource = decadeList;

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            StreamReader babyNames = new StreamReader("05-babynames.txt");
            
           
            myCollection = new List<string>();
            babyList = new List<BabyName>();
            while( babyNames.EndOfStream != true)
            {
               BabyName myBaby = new BabyName(babyNames.ReadLine());
                babyList.Add(myBaby);
                //myCollection.Add(myBaby.Name);
            }
            listBox.ItemsSource = babyList;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
