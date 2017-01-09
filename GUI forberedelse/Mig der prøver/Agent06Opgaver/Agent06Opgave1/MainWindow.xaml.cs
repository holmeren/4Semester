using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;



namespace Agent06Opgave1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Clock clock = new Clock();


        public MainWindow()
        {
            InitializeComponent();
            //btnFrem.Click += new RoutedEventHandler(btnFrem_Click);
            //btnTilbage.Click += new RoutedEventHandler(btnTilbage_Click);
            //btnNy.Click += new RoutedEventHandler(btnNy_Click);

            myClock.DataContext = clock;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

        }
        void Timer_Tick(object sender, EventArgs e)
        {
            clock.Update();
        }


        //private void btnFrem_Click(object sender, RoutedEventArgs e)
        //{
        //    if (lbxAgents.SelectedIndex < lbxAgents.Items.Count - 1)
        //        lbxAgents.SelectedIndex = ++lbxAgents.SelectedIndex;
        //    e.Handled = true;
        //}

        //private void btnTilbage_Click(object sender, RoutedEventArgs e)
        //{
        //    if (lbxAgents.SelectedIndex > 0)
        //        --lbxAgents.SelectedIndex;
        //    e.Handled = true;
        //}

        //private void btnNy_Click(object sender, RoutedEventArgs e)
        //{
        //    Agents agents1 = (Agents) this.FindResource("agents");
        //    agents1.Add(new Agent());
        //    lbxAgents.SelectedIndex = lbxAgents.Items.Count - 1;
        //    e.Handled = true;
        //}
        private void SortOrderCombo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = e.AddedItems[0] as ComboBoxItem;
            string newSortOrder;
            if (cbi != null)
            {
                if (cbi.Tag == null)
                    newSortOrder = "None";
                else
                    newSortOrder = cbi.Tag.ToString();

                SortDescription sortDesc = new SortDescription(newSortOrder, ListSortDirection.Ascending);
                ICollectionView cv = CollectionViewSource.GetDefaultView(DataContext);
                if (cv != null)
                {
                    cv.SortDescriptions.Clear();
                    if (newSortOrder != "None")
                        cv.SortDescriptions.Add(sortDesc);
                }
            }
        }
    }
}
