using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace A01_Euclidean_distance
{
    class Polygon
    {
        public List<Point> points = new List<Point>();

        /// <summary>
        /// Empty constructor, starts with an empty points list.
        /// </summary>
        public Polygon() { }
        /// <summary>
        /// Constructor that loads a point array into the points list.
        /// </summary>
        /// <param name="points">The points that define the polygon.</param>
        public Polygon(Point[] points)
        {
            this.points.AddRange(points);
            
            /*
            foreach (Point po in points)
            {
                this.points.Add(po);
            }
            */
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
        /// <param name="suffix">Suffix for X/Y Coordinate prompt.</param>
        /// <returns>Point instance if everything went well, null if empty or
        /// whitespace was passed to X coordinate.</returns>
        static Point readPoint(string suffix = "")
        {
            // 1. Koordinaten einlesen
            double x = 0.0, y = 0.0;
            bool x_read = false, y_read = false;
            while (!x_read)
            {
                try
                {
                    Console.Write("X{0} (empty to finish reading polygon): ", suffix);
                    string x_line = Console.ReadLine();
                    // If empty or whitespace was given, return a null Point
                    if (string.IsNullOrWhiteSpace(x_line))
                        return null;
                    x = readNumber(x_line);
                    x_read = true;
                }
                catch (FormatException e)
                {
                    throw e;
                }
            }

            while (!y_read)
            {
                try
                {
                    Console.Write("Y{0}: ", suffix);
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
        public static Polygon readPolygon()
        {
            // Jetzt brauchen wir die tatsächliche Punkte
            Polygon poly = new Polygon();
            for (int i = 0; ; ++i)
            {
                Point po = readPoint((i + 1).ToString());
                if (po == null)
                    break;
                //Point po = readPoint();
                poly.points.Add(po);
            }
            return poly;
        }
        public double calculatePerimeter()
        {
            return Polygon.calculatePerimeter(this.points.ToArray());
        }
        public static double calculatePerimeter(Point[] P_v)
        {
            int n = P_v.Length;

            double d_total = 0.0;

            for (int i = 0; i < n; ++i)
            {
                // j = i + 1 --> soll 0 sein, wenn i = n-1
                int j = (i + 1) % n;
                // 1. Variante:
                //    Wir denken nur an die Koordinaten
                /*
                double d_i = Point.distanceTwoPoints(P_v[i].X, P_v[i].Y,
                                                     P_v[j].X, P_v[j].Y);
                */
                // 2. Variante:
                //    Wir denken an "Point" Objekte:
                // double d_i = Point.distanceTwoPoints(P_v[i], P_v[j]);
                //
                // 3. Variante:
                //    Wir agieren direkt zwischen 2 Point Objekten
                double d_i = P_v[i].distanceTo(P_v[j]);
                d_total += d_i;
            }
            return d_total;
        }

        internal double calculateArea()
        {
            return Polygon.calculateArea(this.points.ToArray());
        }

        public static double calculateArea(Point[] P_v)
        {
            int n = P_v.Length;
            // Berechnung nach:
            // https://de.wikipedia.org/wiki/Polygon#Fl.C3.A4che
            double area = 0.0;
            for (int i = 0; i < n; ++i)
            {
                // j = i + 1 --> soll 0 sein, wenn i = n-1
                int j = (i + 1) % n;
                area += Math.Abs(P_v[i].X * P_v[j].Y - P_v[i].Y * P_v[j].X);
            }
            area /= 2.0;

            return area;
        }
    }
}
