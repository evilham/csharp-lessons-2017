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

        public Polygon() { }
        public Polygon(Point[] points)
        {
            this.points.AddRange(points);
        }

        static double readNumber()
        {
            string line = Console.ReadLine().Replace(",", ".");
            return Convert.ToDouble(line, CultureInfo.InvariantCulture);
        }
        public static Polygon readPolygon()
        {
            // Um anzufangen brauchen wir die Anzahl an Vertex/Punkte:
            Console.Write("How many vertices does your polygon have? ");
            int n = Convert.ToInt32(Console.ReadLine());
            // Jetzt brauchen wir die tatsächliche Punkte
            Polygon poly = new Polygon();
            for (int i = 0; i < n; ++i)
            {
                // 1. Koordinaten einlesen
                double x, y;
                Console.Write("X{0}: ", i + 1); // i+1 ist nur für Anzeige
                x = readNumber();

                Console.Write("Y{0}: ", i + 1); // i+1 ist nur für Anzeige
                y = readNumber();
                // 2. Punkt Objekt mit den richtigen Koordinaten erzeugen 
                poly.points.Add(new Point(x, y));
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
