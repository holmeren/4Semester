using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIO = System.IO;

namespace BabyOpgave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[,] rankMatrix = new string[11, 10];
      
        private List<BabyName> babyList;
       
        public MainWindow()
        {
            InitializeComponent();
            //Loaded += new RoutedEventHandler(MainWindow_OnLoaded);
            // listBox1.SelectionChanged += new SelectionChangedEventHandler(listBox1_SelectionChanged);

            PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
        }

        void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.L:
                    {
                        if (Keyboard.Modifiers == ModifierKeys.Control)
                            FontSize += 2;
                    }
                    break;
                case Key.S:
                    {
                        if ((Keyboard.Modifiers == ModifierKeys.Control) && FontSize >= 6)
                            FontSize -= 2;
                    }
                    break;
                default:
                    break;
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            
            StreamReader babyNames = new StreamReader("05-babynames.txt");
            //string file = SIO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "babynames.txt");
            //this.babyList = Utility.ReadBabyNameData(file);

            babyList = new List<BabyName>();
            while (babyNames.EndOfStream != true)
            {
                BabyName myBaby;
                myBaby = new BabyName(babyNames.ReadLine());
               babyList.Add(myBaby);

            }
           
            foreach (BabyName name in babyList)
                for(int decade = 1900; decade < 2010; decade += 10)
            {
                int rank = name.Rank(decade);
                int decadeIndex = (decade - 1900) / 10;
                if (0 < rank && rank < 11)
                    if (rankMatrix[decadeIndex, rank - 1] == null)
                        rankMatrix[decadeIndex, rank - 1] = name.Name;
                    else
                        rankMatrix[decadeIndex, rank - 1] += " and " + name.Name;
            }
           
           
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item;
           
            item = listBox1.SelectedItem as ListBoxItem; // Because the data entries is done by use of ListBoxItem in XAML
         if (item != null)
         {
            int decade = (Convert.ToInt32(item.Content) - 1900) / 10;
            listBox.Items.Clear();
            for (int i = 1; i < 11; ++i)
            {
               listBox.Items.Add(string.Format("{0,2} {1}", i, rankMatrix[decade, i - 1]));
            }
         }

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            listBox2.Items.Clear();
            string searchName = searchBox.Text;
            int average=0;
            int trend = 0;
            int endResults = 0;
            foreach (BabyName name in babyList)
            {
                
                if (searchName == name.Name)
                {
                    textBlock2.Text = name.AverageRank().ToString();
                    textBlock1.Text = name.Trend().ToString();

                    for (int i = 1900; i < 2010; i += 10)
                    {
                        listBox2.Items.Add(string.Format("{0} {1}", i, name.Rank(i)));
                    }
                    ++endResults;
                    
                }
            }
            if (endResults == 0)
            {
                textBlock.Text = searchName + " isn't on the list";
            }
        }
    }
}
