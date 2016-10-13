using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Threading;

//using System.Windows.Forms;
//using System.Drawing;



namespace SimpleDraw
{
    public enum DrawingTool { Line, Ellipsis, Rectangle };
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas myCanvas = new Canvas();
        private bool drag = false;
        Point startPos, lastPos;
        private double wid, hei;
        DrawingTool tool;
        Shape myShape;

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
            lastPos = e.GetPosition(myCanvas);
           if(drag)
            {
                if (tool != DrawingTool.Line)
                {
                    var newX = (startPos.X + (e.GetPosition(myCanvas).X - startPos.X));
                    var newY = (startPos.Y + (e.GetPosition(myCanvas).Y - startPos.Y));
                    Point offset = new Point((startPos.X - lastPos.X), (startPos.Y - lastPos.Y));
                    hei = newY - startPos.Y;
                    wid = newX - startPos.X;

                    if (hei <= 0)
                    {
                        hei = hei * -1;
                        
                        
                        Canvas.SetTop(myShape, lastPos.Y);
                    }


                    if (wid <= 0)
                    {
                        wid = wid * -1;
                       
                        Canvas.SetLeft(myShape, lastPos.X);
                    }

                    myShape.Width = wid;
                    myShape.Height = hei;
                }
                else
                {
                    Line line = myShape as Line;
                    line.X2 = lastPos.X;
                    line.Y2 = lastPos.Y;
                    
                }
                
            }
        }

        private void myMouseDown(object sender, MouseButtonEventArgs e)
        {
            drag = true;
            startPos = e.GetPosition(myCanvas);

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

            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0
               | (Keyboard.Modifiers & ModifierKeys.Alt) != 0)
            {
                if (Keyboard.Modifiers == ModifierKeys.Control)
                {
                    tool = DrawingTool.Ellipsis;
                    myShape = new Ellipse();

                    Canvas.SetLeft(myShape, startPos.X);
                    Canvas.SetTop(myShape, startPos.Y);
                    myShape.Fill = Brushes.Indigo;
                    myShape.Width = wid;
                    myShape.Height = hei;
                    myShape.Stroke = Brushes.Pink;
                    myShape.StrokeThickness = 4;
                    CaptureMouse();
                    myCanvas.Children.Add(myShape);
                }
                else if (Keyboard.Modifiers == ModifierKeys.Alt)
                {
                    tool = DrawingTool.Rectangle;
                    myShape = new Rectangle();

                    
                    myShape.Fill = Brushes.Indigo;

                    myShape.Width = wid;
                    myShape.Height = hei;
                    myShape.Stroke = Brushes.Pink;
                    myShape.StrokeThickness = 4;
                    CaptureMouse();
                    myCanvas.Children.Add(myShape);


                }
            }
            else
            {
                tool = DrawingTool.Line;
                Line line1 = new Line();

                
                line1.Fill = Brushes.Indigo;

                line1.X1 = startPos.X;
                line1.Y1 = lastPos.Y;
                line1.X2 = lastPos.X;
                line1.Y2 = lastPos.Y;
                line1.Stroke = Brushes.Pink;
                line1.StrokeThickness = 4;
                myShape = line1;
                myCanvas.Children.Add(myShape);
            }
            

        }

        private void myMouseUp(object sender, MouseButtonEventArgs e)
        {
            drag = false;
            ReleaseMouseCapture();

        }
    }
}
