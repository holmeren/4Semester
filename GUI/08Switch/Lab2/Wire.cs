using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;


namespace Lab2
{
    class Wire
    {
        #region Datamembers

        private bool current = false;
        private Polyline pl;

        #endregion

        #region Construction

        public Wire(Canvas canvas, params Point[] pts)
        {
            pl = new Polyline();
            pl.Stroke = Brushes.Black;
            pl.StrokeThickness = 2;
            PointCollection myPointCollection = new PointCollection();
            foreach (Point p in pts)
                myPointCollection.Add(p);
            pl.Points = myPointCollection;
            canvas.Children.Add(pl);
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
