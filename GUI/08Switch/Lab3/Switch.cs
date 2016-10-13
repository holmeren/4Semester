using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace Lab3
{
    class Switch
    {
        #region Data members

        protected bool up;
        protected Point location;
        protected Vector con1offset;
        protected Vector con2offset;
        protected Vector con3offset;

        protected Image imSwitch;
        protected BitmapImage imSwUp;
        protected BitmapImage imSwDown;

        Canvas canvas;

        bool dragging = false;
        Vector startPos;

        #endregion

        #region Properties

        public Point Con1
        {
            get
            {
                return location + con1offset;
            }
        }

        public Point Con2
        {
            get
            {
                return location + con2offset;
            }
        }

        public Point Con3
        {
            get
            {
                return location + con3offset;
            }
        }

        public bool Up
        {
            get
            {
                return up;
            }
        }

        #endregion

        #region Events

        public event EventHandler evToggle;
        public event EventHandler evSwitchMoved;


        #endregion

        #region Methods

        public Switch(Canvas canvas, double xloc, double yloc)
        {
            this.canvas = canvas;
            imSwitch = new Image();

            // Read switch images from resources 
            imSwDown = new BitmapImage(new Uri("Images/SwitchDown.bmp", UriKind.Relative));  // Resources may use a forward slash in the path
            imSwUp = new BitmapImage(new Uri(@"Images\SwitchUp.bmp", UriKind.Relative));

            up = true;
            imSwitch.Source = imSwUp;
            imSwitch.MouseDown += new MouseButtonEventHandler(imSwitch_MouseDown);
            imSwitch.MouseMove += new MouseEventHandler(imSwitch_MouseMove);
            imSwitch.MouseUp += new MouseButtonEventHandler(imSwitch_MouseUp);

            location.X = xloc;
            location.Y = yloc;

            canvas.Children.Add(imSwitch);
            Canvas.SetLeft(imSwitch, location.X);
            Canvas.SetTop(imSwitch, location.Y);

            con1offset = new Vector(35, 0);
            con2offset = new Vector(21, 65);
            con3offset = new Vector(49, 65);
        }

        void imSwitch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Toggle();
            }
            if (e.RightButton == MouseButtonState.Pressed)
            {
                dragging = true;
                Mouse.Capture(imSwitch);
                startPos = (Vector)e.GetPosition(imSwitch);
            }
        }

        void imSwitch_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dragging = false;
            Mouse.Capture(null);
        }

        void imSwitch_MouseMove(object sender, MouseEventArgs e)
        {

            if (dragging)
            {
                location = location + (Vector)(e.GetPosition(imSwitch) - startPos);
                Canvas.SetLeft(imSwitch, location.X);
                Canvas.SetTop(imSwitch, location.Y);
                if (evSwitchMoved != null)
                    evSwitchMoved(this, new EventArgs());
            }
        }
        long count = 0;

        public void Toggle()
        {
            up = !up;
            if (up)
                imSwitch.Source = imSwUp;
            else
                imSwitch.Source = imSwDown;
            if (evToggle != null)
                evToggle(this, new EventArgs());
        }

        #endregion
    }
}
