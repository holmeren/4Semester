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
//using System.Windows.Forms;
//using System.Drawing;



namespace SimpleDraw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas myCanvas = new Canvas();
        private bool drag = false;
        Point startPos, lastPos;
        private double wid, hei;


       
        public MainWindow()
        {
            InitializeComponent();


            
            this.Content = myCanvas;
            Ellipse elp1 = new Ellipse();
            myCanvas.Children.Add(elp1);
            Canvas.SetLeft(elp1, 100.0d);
            Canvas.SetTop(elp1, 100.0d);
            elp1.Fill = Brushes.Indigo;
            elp1.Width = 40;
            elp1.Height = 20;
            elp1.Stroke = Brushes.Pink;
            elp1.StrokeThickness = 4;

            //PreviewKeyDown += new KeyEventHandler(MainWindow_PreviewKeyDown);
            MouseLeftButtonDown += new MouseButtonEventHandler(myMouseDown);
            MouseMove += new MouseEventHandler(myMouseMove);
            MouseUp += new MouseButtonEventHandler(myMouseUp);
            // Loaded += new RoutedEventHandler(OnClick);
           


        }

        private void myMouseMove(object sender, MouseEventArgs e)
        {
           if(drag)
            {
                var newX = (startPos.X + (e.GetPosition(myCanvas).X - startPos.X));
                var newY = (startPos.Y + (e.GetPosition(myCanvas).Y - startPos.Y));
                Point offset = new Point((startPos.X - lastPos.X), (startPos.Y - lastPos.Y));
                hei = newY - startPos.Y;
                wid = newX - startPos.X;
                
               
                
            }
        }

        private void myMouseDown(object sender, MouseButtonEventArgs e)
        {
            drag = true;
            startPos = e.GetPosition(myCanvas);
            
        }

        private void myMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (hei <= 0)
            {
                hei = hei * -1;
                startPos.Y = e.GetPosition(myCanvas).Y;
            }


            if (wid <= 0)
            {
                wid = wid * -1;
                startPos.X = e.GetPosition(myCanvas).X;
            }
            
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {

                Ellipse elp1 = new Ellipse();
                myCanvas.Children.Add(elp1);
                Canvas.SetLeft(elp1, startPos.X);
                Canvas.SetTop(elp1, startPos.Y);
                elp1.Fill = Brushes.Indigo;
                elp1.Width = wid;
                elp1.Height = hei;
                elp1.Stroke = Brushes.Pink;
                elp1.StrokeThickness = 4;

            }
            else if (Keyboard.Modifiers == ModifierKeys.Alt)
            {

                Rectangle rec1 = new Rectangle();
                myCanvas.Children.Add(rec1);
                Canvas.SetLeft(rec1, startPos.X);
                Canvas.SetTop(rec1, startPos.Y);
                rec1.Fill = Brushes.Indigo;

                rec1.Width = wid;
                rec1.Height = hei;
                rec1.Stroke = Brushes.Pink;
                rec1.StrokeThickness = 4;


            }
            else
            {
                Line line1 = new Line();
                myCanvas.Children.Add(line1);
                Canvas.SetLeft(line1, startPos.X);
                Canvas.SetTop(line1, startPos.Y);
                line1.Fill = Brushes.Indigo;

                line1.X1 = wid;
                line1.Y1 = hei;
                line1.Stroke = Brushes.Pink;
                line1.StrokeThickness = 4;
            }
            drag = false;
            Cursor = Cursors.Arrow;
            Mouse.Capture(null);
            hei = 40;
            wid = 40;
        }
    }
}
