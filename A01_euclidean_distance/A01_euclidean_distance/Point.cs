using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A01_Euclidean_distance
{
    /// <summary>
    /// A simple container for a 2D point.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// X coordinate of the point.
        /// </summary>
        public double X = 0.0;
        /// <summary>
        /// Y coordinate of the point.
        /// </summary>
        public double Y = 0.0;


        /// <summary>
        /// Empty constructor for coordinates origin.
        /// </summary>
        public Point() { }

        /// <summary>
        /// Basic constructor for our Point class.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Calculate distance from this point to another.
        /// </summary>
        /// <param name="p">Point to calculate distance to</param>
        /// <returns>Distance between two points</returns>
        public double distanceTo(Point p)
        {
            return distanceTwoPoints(this, p);
        }

        /// <summary>
        /// Distance between two points
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <returns>Distance between two points</returns>
        public static double distanceTwoPoints(Point p1, Point p2)
        {
            return distanceTwoPoints(p1.X, p1.Y, p2.X, p2.Y);
        }

        /// <summary>
        /// Distance between two points, defined by its coordinates.
        /// </summary>
        /// <param name="x1">X coordinate of the first point</param>
        /// <param name="y1">Y coordinate of the first point</param>
        /// <param name="x2">X coordinate of the second point</param>
        /// <param name="y2">Y coordinate of the second point</param>
        /// <returns>Distance between two points</returns>
        public static double distanceTwoPoints(double x1, double y1, double x2, double y2)
        {
            double deltaX = (x2 - x1);
            double deltaY = (y2 - y1);

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return distance;
        }
    }
}
