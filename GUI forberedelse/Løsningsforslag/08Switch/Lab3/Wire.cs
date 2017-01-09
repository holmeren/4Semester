using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace Lab3
{
    class Wire
    {
        #region Datamembers

        Canvas canvas;
        private bool current = false;
        private Polyline pl;

        #endregion

        #region Construction

        public Wire(Canvas canvas, params Point[] pts)
        {
            this.canvas = canvas;
            pl = new Polyline();
            pl.Stroke = Brushes.Black;
            pl.StrokeThickness = 2;
            PointCollection myPointCollection = new PointCollection();
            foreach (Point p in pts)
                myPointCollection.Add(p);
            pl.Points = myPointCollection;
            canvas.Children.Add(pl);
        }

        public void Reroute(params Point[] pts)
        {
            //canvas.Children.Remove(pl);
            PointCollection myPointCollection = new PointCollection();
            foreach (Point p in pts)
                myPointCollection.Add(p);
            pl.Points = myPointCollection;
        }


        #endregion

        public bool Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
                if (current)
                    pl.Stroke = Brushes.Red;
                else
                    pl.Stroke = Brushes.Black;
            }
        }
    }
}
