using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Lab3
{
    class Circuit
    {
        Canvas canvas;
        private enum currentWay { no, way1, way2 };

        Image imLamp = new Image();

        BitmapImage imLtOff;
        BitmapImage imLtOn;

        Switch switch1;
        Switch switch2;

        Wire outlet2Lamp;
        Wire lamp2sw1con1;
        Wire sw1con22sw2con3;
        Wire sw1con32sw2con2;
        Wire sw2con12outlet;

        bool lightOn;
        Vector nearDist;
        Vector farDist;

        double yNear;
        double yFar;


        public Circuit(Canvas canvas)
        {
            this.canvas = canvas;
            nearDist = new Vector(0, 10);
            farDist = new Vector(0, 30);

            // Read lamp bitmap images
            imLtOff = new BitmapImage(new Uri(@"Images\LightOFF.bmp", UriKind.Relative));
            imLtOn = new BitmapImage(new Uri(@"Images\LightON.bmp", UriKind.Relative));

            // Put the lamp on the canvas
            imLamp.Source = imLtOff;
            lightOn = false;

            canvas.Children.Add(imLamp);
            Canvas.SetLeft(imLamp, 70.0);
            Canvas.SetTop(imLamp, 5.0);

            // Create switches
            switch1 = new Switch(canvas, 150, 100);
            switch1.evToggle += new EventHandler(switch_evToggle);
            switch1.evSwitchMoved += new EventHandler(switch_evSwitchMoved);
            switch2 = new Switch(canvas, 25, 100);
            switch2.evToggle += new EventHandler(switch_evToggle);
            switch2.evSwitchMoved += new EventHandler(switch_evSwitchMoved);

            // Create and connect wires
            yNear = switch1.Con2.Y + nearDist.Y;
            yFar = switch1.Con2.Y + farDist.Y;
            RouteWires(canvas);
        }

        void switch_evSwitchMoved(object sender, EventArgs e)
        {
            RerouteWires();
        }

        private void RouteWires(Canvas canvas)
        {
            Point[] points;

            // Outlet to lamp
            points = new Point[3];
            points[0] = new Point(0, 79);
            points[1] = new Point(109, 79);
            points[2] = new Point(109, 76);
            outlet2Lamp = new Wire(canvas, points);

            // Lamp  to switch1 con1
            lamp2sw1con1 = new Wire(canvas, RouteLamp2Sw1con1());

            // switch1 con2 to switch2 con3
            sw1con22sw2con3 = new Wire(canvas, RouteSw1con22Sw2con3());

            // switch1 con3 to switch2 con2
            sw1con32sw2con2 = new Wire(canvas, RouteSw1con32Sw2Con2());

            // switch2 con1 to outlet
            sw2con12outlet = new Wire(canvas, RouteSw2con12outlet());
        }

        private Point[] RouteSw2con12outlet()
        {
            Point[] points = new Point[3];
            points[0] = switch2.Con1;
            points[1] = switch2.Con1 - nearDist;
            points[2] = new Point(0.0, switch2.Con1.Y - nearDist.Y);
            return points;
        }

        private Point[] RouteLamp2Sw1con1()
        {
            Point[] points = new Point[4];
            points[0] = new Point(116, 76);
            points[1] = new Point(116, 79);
            points[2] = new Point(switch1.Con1.X, 79);
            points[3] = switch1.Con1;
            return points;
        }

        private Point[] RouteSw1con22Sw2con3()
        {
            Point[] points = new Point[4];
            points[0] = switch1.Con2;
            points[1] = new Point(switch1.Con2.X, yNear);
            points[2] = new Point(switch2.Con3.X, yNear);
            points[3] = switch2.Con3;
            return points;
        }

        private Point[] RouteSw1con32Sw2Con2()
        {
            Point[] points = new Point[4];
            points[0] = switch1.Con3;
            points[1] = new Point(switch1.Con3.X, yFar);
            points[2] = new Point(switch2.Con2.X, yFar);
            points[3] = switch2.Con2;
            return points;
        }



        private void RerouteWires()
        {
            if (switch1.Con2.Y < switch2.Con2.Y)
            {
                yNear = switch2.Con2.Y + nearDist.Y;
                yFar = switch2.Con2.Y + farDist.Y;
            }
            else
            {
                yNear = switch1.Con2.Y + nearDist.Y;
                yFar = switch1.Con2.Y + farDist.Y;
            }
            lamp2sw1con1.Reroute(RouteLamp2Sw1con1());
            sw1con22sw2con3.Reroute(RouteSw1con22Sw2con3());
            sw1con32sw2con2.Reroute(RouteSw1con32Sw2Con2());
            sw2con12outlet.Reroute(RouteSw2con12outlet());
        }

        void switch_evToggle(object sender, EventArgs e)
        {
            if (lightOn)
            {
                lightOn = false;
                imLamp.Source = imLtOff;
                SetCurrent(currentWay.no);
            }
            else
            {
                lightOn = true;
                imLamp.Source = imLtOn;
                if (switch1.Up)
                    SetCurrent(currentWay.way2);
                else
                    SetCurrent(currentWay.way1);
            };
        }

        private void SetCurrent(currentWay way)
        {
            switch (way)
            {
                case currentWay.no:
                    outlet2Lamp.Current = false;
                    lamp2sw1con1.Current = false;
                    sw1con22sw2con3.Current = false;
                    sw1con32sw2con2.Current = false;
                    sw2con12outlet.Current = false;
                    break;
                case currentWay.way1:
                    outlet2Lamp.Current = true;
                    lamp2sw1con1.Current = true;
                    sw1con22sw2con3.Current = true;
                    sw1con32sw2con2.Current = false;
                    sw2con12outlet.Current = true;
                    break;
                case currentWay.way2:
                    outlet2Lamp.Current = true;
                    lamp2sw1con1.Current = true;
                    sw1con22sw2con3.Current = false;
                    sw1con32sw2con2.Current = true;
                    sw2con12outlet.Current = true;
                    break;
                default:
                    break;
            }
        }
    }
}
