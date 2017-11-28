using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace A01_Euclidean_distance
{
    class Program
    {
        static double readNumber()
        {
            string line = Console.ReadLine().Replace(",", ".");
            return Convert.ToDouble(line, CultureInfo.InvariantCulture);
        }
        static void Main(string[] args)
        {
            // Beispiel Polygone, für die wir Ergebniss kennen.
            Point[] square_3x3 =
            {
                new Point(0, 0),
                new Point(3, 0),
                new Point(3, 3),
                new Point(0, 3),
            }; // Area 9, Perimeter: 12
            Point[] triangle_b2_h1 =
            {
                new Point(-1, 0),
                new Point(0, 1),
                new Point(1, 0),
            }; // Area 1, Perimeter: 4.8284
            Point[] triangle_b3_h5 =
            {
                new Point(-1.5, 0),
                new Point(0, 5),
                new Point(1.5, 0),
            }; // Area 7.5, Perimeter: 13.4403

            // 1. test
            calcPolygon(square_3x3);
            calcPolygon(triangle_b2_h1);
            calcPolygon(triangle_b3_h5);

            // 2. Interactive mode
            string[] affirmative = new string[] { "YES", "Y", "JA", "J" };
            do
            {
                calcPolygon(readPolygon());
                Console.Write("\nRead another polygon? (y/[n]) ");
            } while (affirmative.Contains(Console.ReadLine().ToUpperInvariant()));
            Console.Write("\nBye bye! ");
            Console.ReadLine();
        }
        public static Point[] readPolygon()
        {
            // Um anzufangen brauchen wir die Anzahl an Vertex/Punkte:
            Console.Write("How many vertices does your polygon have? ");
            int n = Convert.ToInt32(Console.ReadLine());
            // Jetzt brauchen wir die tatsächliche Punkte
            Point[] P_v = new Point[n];
            for (int i = 0; i < n; ++i)
            {
                // 1. Koordinaten einlesen
                double x, y;
                Console.Write("X{0}: ", i + 1); // i+1 ist nur für Anzeige
                x = readNumber();

                Console.Write("Y{0}: ", i + 1); // i+1 ist nur für Anzeige
                y = readNumber();
                // 2. Punkt Objekt mit den richtigen Koordinaten erzeugen 
                P_v[i] = new Point(x, y);
            }
            return P_v;
        }
        public static void calcPolygon(Point[] P_v)
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

            Console.WriteLine("Perimeter: {0}", d_total);

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

            Console.WriteLine("Area: {0}", area);
        }
    }
}
