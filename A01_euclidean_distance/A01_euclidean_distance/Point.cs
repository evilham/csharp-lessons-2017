using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A01_Euclidean_distance
{
    public class Point
    {
        public double X = 0.0;
        public double Y = 0.0;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double distanceTo(Point p)
        {
            return distanceTwoPoints(this, p);
        }

        public static double distanceTwoPoints(Point p1, Point p2)
        {
            return distanceTwoPoints(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static double distanceTwoPoints(double x1, double y1, double x2, double y2)
        {
            double deltaX = (x2 - x1);
            double deltaY = (y2 - y1);

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distance;
        }
    }
}
