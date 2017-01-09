using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Lab2
{
    class Circuit
    {
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

        public Circuit(Canvas canvas)
        {
            // Read lamp bitmap images
            imLtOff = new BitmapImage(new Uri("Images\\LightOFF.bmp", UriKind.Relative));
            imLtOn = new BitmapImage(new Uri("Images\\LightON.bmp", UriKind.Relative));

            // Put the lamp on the canvas
            imLamp.Source = imLtOff;
            lightOn = false;

            canvas.Children.Add(imLamp);
            Canvas.SetLeft(imLamp, 70.0);
            Canvas.SetTop(imLamp, 5.0);

            // Create switches
            switch1 = new Switch(canvas, 150, 100);
            switch1.evToggle += new EventHandler(switch_evToggle);
            switch2 = new Switch(canvas, 25, 100);
            switch2.evToggle += new EventHandler(switch_evToggle);

            // Create and connect wires
            // ----------------------------------------------------------------
            Vector nearDist = new Vector(0, 10);
            Vector farDist = new Vector(0, 30);
            Point[] points;

            // Outlet to lamp
            points = new Point[3];
            points[0] = new Point(0, 79);
            points[1] = new Point(109, 79);
            points[2] = new Point(109, 76);
            outlet2Lamp = new Wire(canvas, points);

            // Lamp  to switch1 con1
            points = new Point[4];
            points[0] = new Point(116, 76);
            points[1] = new Point(116, 79);
            points[2] = new Point(switch1.Con1.X, 79);
            points[3] = switch1.Con1;
            lamp2sw1con1 = new Wire(canvas, points);

            // switch1 con2 to switch2 con3
            points = new Point[4];
            points[0] = switch1.Con2;
            points[1] = switch1.Con2 + nearDist;
            points[2] = switch2.Con3 + nearDist;
            points[3] = switch2.Con3;
            sw1con22sw2con3 = new Wire(canvas, points);

            // switch1 con3 to switch2 con2
            points = new Point[4];
            points[0] = switch1.Con3;
            points[1] = switch1.Con3 + farDist;
            points[2] = switch2.Con2 + farDist;
            points[3] = switch2.Con2;
            sw1con32sw2con2 = new Wire(canvas, points);

            // switch2 con1 to outlet
            points = new Point[3];
            points[0] = switch2.Con1;
            points[1] = switch2.Con1 - nearDist;
            points[2] = new Point(0.0, switch2.Con1.Y - nearDist.Y);
            sw2con12outlet = new Wire(canvas, points);
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
