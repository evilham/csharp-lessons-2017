using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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
        static double readNumber(string line = null)
        {
            if (line == null)
                line = Console.ReadLine();

            line = line.Replace(",", ".");
            return Convert.ToDouble(line, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Read a 2 dimensional point from the Console.
        /// If X coordinate is empty or whitespace, a null Point is returned.
        /// IF a wrong number is passed, the user is asked to try again.
        /// </summary>
        /// <param name="suffixX">Suffix for X Coordinate prompt.</param>
        /// <param name="suffixY">Suffix for Y Coordinate prompt. If ommited, suffixX will be used.</param>
        /// <returns>Point instance if everything went well, null if empty or
        /// whitespace was passed to X coordinate.</returns>
        public static Point readPoint(string suffixX = "", string suffixY = null)
        {
            if (suffixY == null)
                suffixY = suffixX;
            // 1. Koordinaten einlesen
            double x = 0.0, y = 0.0;
            bool x_read = false, y_read = false;
            while (!x_read)
            {
                try
                {
                    Console.Write("X{0}: ", suffixX);
                    string x_line = Console.ReadLine();
                    // If empty or whitespace was given, return a null Point
                    if (string.IsNullOrWhiteSpace(x_line))
                        return null;
                    x = readNumber(x_line);
                    x_read = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("WARNING: Could not read X coordinate, try again.");
                    throw e;
                }
            }

            while (!y_read)
            {
                try
                {
                    Console.Write("Y{0}: ", suffixY);
                    y = readNumber();
                    y_read = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("WARNING: Could not read Y coordinate, try again.");
                }
            };
            // 2. Punkt Objekt mit den richtigen Koordinaten erzeugen 
            return new Point(x, y);
        }
    }
}
